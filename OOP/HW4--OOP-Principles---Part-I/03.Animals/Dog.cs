using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    public class Dog: Animal
    {
        // Constructor
        public Dog(string name, int age, Sex animalSex)
            : base(name, age, animalSex)
        {
        }

        public override string Soud()
        {
            return "Bau!";
        }
        public override string ToString()
        {
            return String.Format("I am a Dog {0} at {1}age and say {2}", Name, Age, Soud());
        }
    }
}
