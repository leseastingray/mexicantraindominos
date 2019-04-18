using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    /// <summary>
    /// BoneYard is a class describing a deck of Dominos.
    /// </summary>
    public class BoneYard : IEnumerable<Domino>
    {
        /// <summary>
        /// Delegate with signature of public void Name(BoneYard)
        /// </summary>
        /// <param name="by"></param>
        public delegate void EmptyHandler(BoneYard by);
        /// <summary>
        /// Event
        /// </summary>
        public event EmptyHandler Empty;

        // field declaring and instantiating list of dominos.
        private List<Domino> dList = new List<Domino>();
        
        /// <summary>
        /// Generates BoneYard object given the int of maxDots.
        /// </summary>
        /// <param name="maxDots"></param>
        public BoneYard(int maxDots)
        {
            // to fill, loop through side 1
            //    then loop through side 2 beginning at side 1's number
            for (int side1 = 0; side1 <= maxDots; side1++)
            {
                for (int side2 = side1; side2 <= maxDots; side2++)
                {
                    dList.Add(new Domino(side1, side2));
                }
            }
            // 
            Empty = new EmptyHandler(HandleEmpty);
        }
        /// <summary>
        /// HandleEmpty 
        /// </summary>
        /// <param name="by"></param>
        public void HandleEmpty(BoneYard by)
        {
        }

        /// <summary>
        /// This method shuffles the Dominos in the
        /// Domino BoneYard
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
            for (int i = 0; i < dList.Count; i++)
            {
                int randomIndex = rand.Next(1, dList.Count);
                Domino temp = dList[i];
                dList[i] = dList[randomIndex];
                dList[randomIndex] = temp;
            }
        }
        /// <summary>
        /// This method returns a bool indicating if the BoneYard is empty.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            // if domino list count is equal to 0
            //     return true
            // else
            //     return false
            if (dList.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// This property provides an int describing the number of Dominos left
        /// in the BoneYard.
        /// </summary>
        public int DominosRemaining
        {
            // return the count of the domino list
            get
            {
                return dList.Count;
            }
        }
        /// <summary>
        /// This removes the Domino at index 0 of the BoneYard.
        /// </summary>
        /// <returns></returns>
        public Domino Draw()
        {
            // create variable to store index 0 of domino list
            // remove the above domino from the domino list
            if (dList.Count != 0)
            {
                Domino drawn = dList[0];
                dList.Remove(drawn);
                // if boneyard is now empty
                //      raise event Empty
                if (IsEmpty())
                {
                    Empty(this);
                }
                // return drawn domino
                return drawn;
            }
            else
            {
                throw new Exception("BoneYard is empty!");
            }
        }
        /// <summary>
        /// Indexer for the BoneYard
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Domino this[int index]
        {
            get
            {
                return dList[index];
            }
        }
        /// <summary>
        /// ToString override method.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string output = "";

            foreach (Domino domino in dList)
            {
                output += domino.ToString() + "/n";
            }
            return output;
        }
        /// <summary>
        /// IEnumerable interface method allowing for foreach loop
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Domino> GetEnumerator()
        {
            foreach (Domino d in dList)
            {
                yield return d;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
