using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    /// <summary>
    /// Derived class of Train base class
    /// </summary>
    public class MexicanTrain : Train
    {
        /// <summary>
        /// overloaded constructor, takes int engValue as parameter
        /// </summary>
        /// <param name="engValue"></param>
        public MexicanTrain(int engValue)
        {
            List<Domino> mxTrain = new List<Domino>(engValue);
        }

        public bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {

        }

    }
}
