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
        
        public void Shuffle()
        {
            Random rand = new Random();

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
            get
            {
                return dlist.Count;
            }
        }

        public Domino Draw()
        {
            Domino drawn = dlist[0];
            dlist.Remove(drawn);
            return drawn;
        }
        // Test and check 
        public Domino this[int index]
        {
            get
            {
                return dlist[index];
            }
        }
        
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
