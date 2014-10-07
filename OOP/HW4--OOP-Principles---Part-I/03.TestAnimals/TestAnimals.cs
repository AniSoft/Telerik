using _03.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.TestAnimals
{
    class TestAnimals
    {
        static void Main()
        {
            Frog[] frogs = new Frog[5]
            {
                new Frog("Jabcho",1,Sex.male),
                new Frog("Jabok",2,Sex.male),
                new Frog("Jabka",3,Sex.female),
                new Frog("Jabchocho",1,Sex.male),
                new Frog("Jabkaka",3,Sex.female)
            };
            Dog[] dogs = new Dog[6]
            {
                new Dog("Balkan",4,Sex.male),
                new Dog("Mecho",5,Sex.male),
                new Dog("Rex",8,Sex.female),
                new Dog("Sharo",1,Sex.male),
                new Dog("Puffi",3,Sex.female),
                new Dog("Gudjo",5,Sex.male)
            };
            Cat[] cats = new Cat[8]
            {
                new Cat("Mats",1,Sex.male),
                new Cat("Lucky",2,Sex.female),
                new Kitten("Jabka",3),
                new Cat("Kotancho",2,Sex.male),
                new Kitten("Pissi",3),
                new Tomcat("Lucky",4),
                new Tomcat("Kotak",4),
                new Tomcat("MatsMats",3)
            };
            PrintToConsole(frogs);
            PrintToConsole(dogs);
            PrintToConsole(cats);
            
        }

        private static void PrintToConsole(Animal[] animals)
        {
            foreach (var item in animals)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Average age of {0} are {1}", animals.GetType().Name.Substring(0, animals.GetType().Name.Length - 2) + "s", Math.Round(animals.Average(x => x.Age)), 2);
            Console.WriteLine();
        }
    }
}
