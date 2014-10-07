using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_05.LinqAndLambdaOverStudentClass
{
    public class Student
    {
        private int age;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age
        {
            get { return age; }
            set { 
                if(value < 1 || value > 200)
                {
                    throw new ArgumentOutOfRangeException("age must be between (1 - 200)");
                }
                else
                {
                    this.age = value;
                }
            }
        }

        //Constructor
        public Student(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} at {2} age", FirstName, LastName, Age);
        }
    }
}
