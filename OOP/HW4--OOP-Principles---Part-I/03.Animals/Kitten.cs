using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    public class Kitten : Cat
    {
        // Constructor
        public Kitten(string name, int age)
            : base(name, age, Sex.female)
        {
        }

        public override string Soud()
        {
            return "Miaaau!";
        }
        public override string ToString()
        {
            return String.Format("I am a Kitten {0} at {1}age and say {2}",Name,Age,Soud());
        }
    }
}
