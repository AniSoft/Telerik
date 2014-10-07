using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Person
{
    public class Person
    {
        public string Name { get; set; }
        private int? age;

        public int? Age
        {
            get { return age; }
            set
            {
                if (value <= 0 || value > 150)
                {
                    throw new ArgumentOutOfRangeException("Age must be positive number smaller than 150");
                }
                else
                {
                    age = value;
                }
            }
        }
        //Constructor
        public Person(string name)
        {
            this.Name = name;
        }
        public Person(string name, int? age)
            :this(name)
        {
            this.Age = age;
        }

        public override string ToString()
        {
            string result = String.Format("Person: {0} at age:", Name);
            if (Age == null)
            {
                result += "Not specified!";
            }
            else
            {
                result += Age;
            }
            return result;
        }
    }
}
