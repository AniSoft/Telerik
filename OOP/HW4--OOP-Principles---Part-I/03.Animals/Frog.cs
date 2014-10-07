using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    public class Frog: Animal
    {
        // Constructor
        public Frog(string name, int age, Sex animalSex)
            : base(name, age, animalSex)
        {
        }

        public override string Soud()
        {
            return "Kwak!";
        }
        public override string ToString()
        {
            return String.Format("I am a Frog {0} at {1}age and say {2}", Name, Age, Soud());
        }
    }
}
