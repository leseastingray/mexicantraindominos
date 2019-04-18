using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTDClasses
{
    /// <summary>
    /// Represents a generic Train for MTD
    /// </summary>
    public abstract class Train
    {
        /// <summary>
        /// fields
        /// </summary>
        protected List<Domino> dominos = new List<Domino>();
        int engineValue = -1;

        /// <summary>
        /// default constructor
        /// </summary>
        public Train()
        {
            dominos = new List<Domino>();
        }
        /// <summary>
        /// overloaded constructor, takes int engValue as parameter
        /// </summary>
        /// <param name="engValue"></param>
        public Train(int engValue)
        {
            List<Domino> dominos = new List<Domino>(engValue);
        }
        /// <summary>
        /// returns int representing the number of Dominos in the Train
        /// </summary>
        public int Count
        {
            get
            {
                return dominos.Count();
            }
        }

        /// <summary>
        /// The first domino value that must be played on a train
        /// </summary>
        public int EngineValue
        {
            get
            {
                // if there are more than 0 dominos
                //  engineValue is the value of side 2 of
                //  the first Domino (index 0)
                // else engineValue remains at -1
                if (dominos.Count > 0)
                {
                    engineValue = dominos[0].Side2;
                }
                else
                {
                    engineValue = -1;
                }
                return engineValue;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                if (dominos.Count == 0)
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
        /// 
        /// </summary>
        public Domino LastDomino
        {
            get
            {
                if (dominos.Count != 0)
                {
                    Domino lastDomino = dominos.Last<Domino>();
                    return lastDomino;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Side2 of the last domino in the train.  It's the value of the next domino that can be played.
        /// </summary>
        public int PlayableValue
        {
            get
            {
                Domino valuedDomino = dominos.Last<Domino>();
                if (dominos.Count > 1)
                {
                    return valuedDomino.Side2;
                }
                else if (dominos.Count == 1)
                {
                    return engineValue;
                }
                else
                {
                    return -1;
                }
                
            }
        }
        /// <summary>
        /// adds a domino to the Train.
        /// </summary>
        /// <param name="d"></param>
        public void Add(Domino d)
        {
            dominos.Add(d);
        }
        /// <summary>
        /// indexer
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Domino this[int index]
        {
            get
            {
                return dominos[index];
            }
        }

        /// <summary>
        /// Determines whether a hand can play a specific domino on this train and if the domino must be flipped.
        /// Because the rules for playing are different for Mexican and Player trains, this method is abstract.
        /// </summary>
        public abstract bool IsPlayable(Hand h, Domino d, out bool mustFlip);

        /// <summary>
        /// A helper method that determines whether a specific domino can be played on this train.
        /// It can be called in the Mexican and Player train class implementations of the abstract method
        /// </summary>
        protected virtual bool IsPlayable(Domino d, out bool mustFlip)
        {
            if (!IsEmpty)
            {
                if(engineValue == d.Side1)
                {
                    mustFlip = false;
                    return true;
                }
                else if (engineValue == d.Side2)
                {
                    mustFlip = true;
                    return false;
                }
                else
                {
                    mustFlip = false;
                    return false;
                }
            }
            else
            {
                mustFlip = false;
                return false;
            }
        }
        /// <summary>
        /// Play method
        /// </summary>
        /// <param name="h"></param>
        /// <param name="d"></param>
        public void Play(Hand h, Domino d)
        {
            bool mustFlip = false;
            if (IsPlayable(h,d, out mustFlip))
            {
                if (mustFlip)
                {
                    d.Flip();
                }
                Add(d);
            }
            else
            {
                throw new Exception("Domino" + d.ToString() + " is not playable here.");
            }
        }
        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < dominos.Count; i++)
            {
                output += dominos[i].ToString() + "/n";
            }
            return output;
        }      
    }
}