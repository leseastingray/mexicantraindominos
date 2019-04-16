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
        public MexicanTrain(int engValue) : base(engValue)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="h"></param>
        /// <param name="d"></param>
        /// <param name="mustFlip"></param>
        /// <returns></returns>
        public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {
            return base.IsPlayable(d, out mustFlip);
        }

    }
}
