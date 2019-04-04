using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    [Serializable()]
    public class Domino
    {
        // instance variables
        private int side1;
        private int side2;

        // Default constructor, creates blank (0,0) domino
        public Domino()
        {
            side1 = 0;
            side2 = 0;
        }
        // Overloaded constructor
        public Domino(int p1, int p2)
        {
            side1 = p1;
            side2 = p2;
        }

        // don't use an auto implemented property because of the validation in the setter - p 390
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
        // Method to swap sides
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

        // This is how I would have done this in 233N
        // Get only property
        public int Score
        {
            get
            {
                return side1 + side2;
            }
        }

        // because it's a read only property, I can use the "expression bodied syntax" or a lamdba expression - p 393
        //public int Score => side1 + side2;

        //ditto for the first version of this method and the next one
        public bool IsDouble()
        {
            if (side1 == side2)
                return true;
            else
                return false;
        }

        // could you do this one using a lambda expression?
        public string Filename
        {
            get
            {
                return String.Format("d{0}{1}.png", side1, side2);
            }
        }

        //public bool IsDouble() => (side1 == side2) ? true : false;

        public override string ToString()
        {
            return String.Format("Side 1: {0}  Side 2: {1}", side1, side2);
        }

        // could you overload the == and != operators?
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

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
