using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class Student : Person
    {
        private int uniqueNumber;
        public int UniqueNumber
        {
            get { return this.uniqueNumber; }
            set
            {
                if (value.ToString().Length != 6)
                {
                    throw new ArgumentOutOfRangeException("uniqueNumber must be with 6 digits");
                }
                else
                {
                    this.uniqueNumber = value;
                }
            }
        }

         // Constructor
        public Student(string name, int uniqueNumber)
            : base(name)
        {
            this.UniqueNumber = uniqueNumber;
        }

        public override string ToString()
        {
            return String.Format("{0} - ID {1}", this.Name, this.UniqueNumber);
        }
    }
}
