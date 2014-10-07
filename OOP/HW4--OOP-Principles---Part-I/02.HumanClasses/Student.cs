using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.HumanClasses
{
    public class Student : Human
    {
        private int grade;
        public int Grade
        {
            get
            {
                return grade;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Grade must be a positive number.");
                }
                grade = value;
            }
        }

        
        // Constructor
        public Student(string firstName, string lastName, int grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }
        public override string ToString()
        {
            return String.Format("{0} {1} at {2} grade", FirstName, LastName, Grade);
        }
    }
}
