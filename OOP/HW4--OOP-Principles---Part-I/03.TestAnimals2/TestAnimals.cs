using _03.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.TestAnimals2
{
    class TestAnimals
    {
        static void Main()
        {
            List<Animal> animals = new List<Animal>()
            {
                new Frog("Jabcho",1,Sex.male),
                new Dog("Balkan",4,Sex.male),
                new Cat("Kotancho",2,Sex.male),
                new Frog("Jabok",2,Sex.male),
                new Kitten("Jabka",3),
                new Frog("Jabkaka",3,Sex.female),
                new Dog("Rex",8,Sex.female),
                new Tomcat("Kotak",4),
                new Frog("Jabchocho",1,Sex.male),
                new Dog("Gudjo",5,Sex.male),
                new Cat("Mats",1,Sex.male),
                new Cat("Lucky",2,Sex.female),
                new Dog("Sharo",1,Sex.male),
                new Kitten("Pissi",3),
                new Dog("Mecho",5,Sex.male),
                new Tomcat("Lucky",4),
                new Frog("Jabka",3,Sex.female),
                new Dog("Puffi",3,Sex.female),
                new Tomcat("MatsMats",3)
            };
            var animalGroups =
                (from animal in animals
                 group animal by animal.GetType().Name into groups
                 select new
                 {
                     groupName = groups.Key,
                     averageSum =
                         (from anim in groups
                          select anim.Age).Average(),
                          groupList = groups.ToList()
                 });

            foreach (var group in animalGroups)
            {
                foreach (var item in group.groupList)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Average age of {0} are {1}", group.groupName + "s", Math.Round(group.averageSum), 2);
                Console.WriteLine();
            }
        }
    }
}
