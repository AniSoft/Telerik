using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    public abstract class Animal: ISound
    {
        private int age;
        public string Name { get; set; }
        public Sex AnimalSex{ get; set; }
        public int Age
        {
            get { return age; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Age must be positive");
                }
                else
                {
                    age = value;
                }
            }
        }
        // Constructor
        public Animal(string name, int age, Sex animalSex)
        {
            this.Name = name;
            this.Age = age;
            this.AnimalSex = animalSex;
        }
        public abstract string Soud();
    }
}
