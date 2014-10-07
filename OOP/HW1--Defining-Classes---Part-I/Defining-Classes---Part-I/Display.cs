namespace Defining_Classes___Part_I
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Display
    {
        // Fields
        private double size;
        private int numberofColors;

        //Properties
        public double Size
        {
            get { return this.size; }

            set
            {
                if (value >= 0)
                {
                    this.size = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("size","Size can't be negative!");
                }
            }
        }

        public int NumberofColors
        {
            get { return this.numberofColors; }

            set
            {
                if (value >= 0)
                {
                    this.numberofColors = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("numberofColors","NumberofColors can't be negative!");
                }
            }
        }

        //Constructors
        public Display()
            : this(0, 0)   // Reuse the down constructor
        {
        }

        public Display(int size, int numberofColors)
        {
            this.Size = size;
            this.NumberofColors = numberofColors;
        }

    }
}
