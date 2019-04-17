using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    /// <summary>
    /// Derived class of Train base class.
    /// </summary>

    public class PlayerTrain : Train
    {
        /// <summary>
        /// Field variables
        /// </summary>
        private Hand currentHand;
        private bool open = false;
        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="h"></param>
        public PlayerTrain(Hand h): base()
        {
            currentHand = h;
        }

        /// <summary>
        /// This is the most appropriate constructor for the class.
        /// </summary>
        /// <param name="h">Represents the Hand object to which the train belongs</param>
        /// <param name="engineValue">Represents the first playable value on the train</param>
        public PlayerTrain(Hand h, int engineValue) : base (engineValue)
        {
            currentHand = h;
        }

        /// <summary>
        /// Returns whether or not the train is open.  An open train
        /// can be played upon by any player.
        /// </summary>
        public bool IsOpen
        {
            get
            {
                if (open == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Opens the train
        /// </summary>
        public void Open()
        {
            if (open == false)
            {
                open = true;
            }
        }

        /// <summary>
        /// Close the train
        /// </summary>
        public void Close()
        {
            if (open == true)
            {
                open = false;
            }
        }

        /// <summary>
        /// Can the domino d be played by the hand h on this train?
        /// If it can be played, must it be flipped to do so?
        /// </summary>
        /// <param name="d"></param>
        /// <param name="mustFlip"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {
            if (IsOpen || currentHand == h)
            {
                if (base.IsPlayable(d, out mustFlip))
                {
                    return true;
                }
                return false;
            }
            mustFlip = false;
            return false;
        }
    }
}
