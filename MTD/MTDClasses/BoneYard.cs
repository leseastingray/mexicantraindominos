using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    public class BoneYard
    {
        // field declaring and instantiating list of dominos.
        private List<Domino> dlist = new List<Domino>();
        
        public BoneYard(int maxDots)
        {
            // to fill, loop through side 1
            //    then loop through side 2 beginning at side 1's number
            for (int side1 = 0; side1 <= maxDots; side1++)
            {
                for (int side2 = side1; side2 <= maxDots; side2++)
                {
                    dlist.Add(new Domino(side1, side2));
                }
            }
        }
        /// <summary>
        /// This method shuffles the dominos in the
        /// domino list
        /// </summary>
        public void Shuffle()
        {
            // random generator
            Random rand = new Random();

            // for each domino in the domino list
            //   generate a random index number
            //   create variable to store domino index i
            //   store random index domino in domino list at i
            //   assign temp to domino list at random index
            for (int i = 0; i < dlist.Count; i++)
            {
                int randomIndex = rand.Next(1, dlist.Count);
                Domino temp = dlist[i];
                dlist[i] = dlist[randomIndex];
                dlist[randomIndex] = temp;
            }
        }
        
        public bool IsEmpty()
        {
            // if domino list count is equal to 0
            //     return true
            // else
            //     return false
            if (dlist.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public int DominosRemaining
        {
            // return the count of the domino list
            get
            {
                return dlist.Count;
            }
        }

        public Domino Draw()
        {
            // create variable to store index 0 of domino list
            // remove the above domino from the domino list
            // return drawn domino
            Domino drawn = dlist[0];
            dlist.Remove(drawn);
            return drawn;
        }
        // indexer
        public Domino this[int index]
        {
            get
            {
                return dlist[index];
            }
        }
        // tostring override
        public override string ToString()
        {
            string output = "";

            foreach (Domino domino in dlist)
            {
                output += domino.ToString() + "/n";
            }
            return output;
        }
    }
}
