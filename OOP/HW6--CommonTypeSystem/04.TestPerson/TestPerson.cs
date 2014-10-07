using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04.Person;

namespace _04TestPerson
{
    class TestPerson
    {
        static void Main()
        {
            List<Person> people = new List<Person>() {
            new Person("Ivan Stoyanov"),
            new Person("Asen Petrov", 29),
            new Person("Georgi Ivanov", 38),
            new Person("Dragancho"),
            new Person("Pesho", 25)
            };

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }

        }
    }
}
