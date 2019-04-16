using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    /// <summary>
    /// This is a class representing a Domino.
    /// </summary>
    [Serializable()]
    public class Domino : IComparable<Domino>
    {
        // instance variables
        private int side1;
        private int side2;

        /// <summary>
        /// Default constructor for a blank (0/0) Domino
        /// </summary>
        public Domino()
        {
            side1 = 0;
            side2 = 0;
        }
        /// <summary>
        /// Overloaded constructor for a Domino given ints
        /// side1, side2.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public Domino(int p1, int p2)
        {
            side1 = p1;
            side2 = p2;
        }

        /// <summary>
        /// This property gets or sets Side1 of the Domino.
        /// </summary>
        public int Side1
        {
            get
            {
                return side1;
            }
            set
            {
                if (value >= 0 && value <= 12)
                    side1 = value;
                else
                    throw new ArgumentException("Domino number of dots must be between 0 and 12.");
            }
        }
        /// <summary>
        /// This property gets or sets Side2 of the Domino.
        /// </summary>
        public int Side2
        {
            get
            {
                return side2;
            }
            set
            {
                if (value >= 0 && value <= 12)
                    side2 = value;
                else
                    throw new ArgumentException("Domino number of dots must be between 0 and 12.");
            }
        }
        /// <summary>
        /// This method flips the sides on the Domino.
        /// </summary>
        public void Flip()
        {
            // variables to hold value of each side
            side1 = this.Side1;
            side2 = this.Side2;

            // assign side 1 to temp
            // assign side 2 to side 1
            // addign temp to side 2
            int temp = side1;
            side1 = side2;
            side2 = temp;
        }

        /// <summary>
        /// This is a read-only property for the Domino,
        /// returning an int representing the Domino's score.
        /// </summary>
        public int Score
        {
            get
            {
                return side1 + side2;
            }
        }

        // because it's a read only property, I can use the "expression bodied syntax" or a lamdba expression - p 393
        //public int Score => side1 + side2;

        /// <summary>
        /// This method returns a bool indicating if the Domino
        /// is a double, ie if side1 is equal to side2.
        /// </summary>
        /// <returns></returns>
        public bool IsDouble()
        {
            if (side1 == side2)
                return true;
            else
                return false;
        }

        /// <summary>
        /// This property returns a string of the name of the
        /// Domino's image file.
        /// </summary>
        public string Filename
        {
            get
            {
                return String.Format("d{0}{1}.png", side1, side2);
            }
        }

        //public bool IsDouble() => (side1 == side2) ? true : false;
        /// <summary>
        /// This is the override of the ToString method.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("Side 1: {0}  Side 2: {1}", side1, side2);
        }

        /// <summary>
        /// This is an override of the Equals method, returning a bool
        /// telling if the Domino's sides are equal to another Domino
        /// object given as a parameter.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else
            {
                Domino domi = (Domino)obj;
                if (domi.Side1 == this.Side1 && domi.Side2 == this.Side2)
                    return true;
                else
                    return false;
            }      
        }
        /// <summary>
        /// This is the GetHashCode method returning an int
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        /// <summary>
        /// CompareTo Interface Method
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Domino other)
        {
            return this.Score.CompareTo(other.Score);
        }
    }
}
