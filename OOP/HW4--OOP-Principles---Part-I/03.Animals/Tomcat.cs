using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    public class Tomcat : Cat
    {
        // Constructor
        public Tomcat(string name, int age)
            : base(name, age, Sex.male)
        {
        }

        public override string Soud()
        {
            return "Miauu!";
        }
        public override string ToString()
        {
            return String.Format("I am a Tomvat {0} at {1}age and say {2}", Name, Age, Soud());
        }
    }
}
