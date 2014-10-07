using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.HumanClasses;

namespace _02.TestHumanClasses
{
    class TestHumanClasses
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
            {
                new Student("Svetla", "Velikova", 3),
                new Student("Kristina", "Ivanova", 2),
                new Student("Jana"	, "Kazarova", 1),
                new Student("Hrisi"	, "Dimitrova", 4),
                new Student("Diyana", "Dobreva", 3),
                new Student("Nina"	, "Nikolova", 3),
                new Student("Kristian", "Milev",6),                
                new Student("Damian", "Stoyanov"  , 4),
                new Student("Liubomir", "Slavchev", 2),
                new Student("Damian", "Apostolov"  , 5)
            };
            List<Worker> workers = new List<Worker>()
            {
                new Worker("Gergana", "Georgieva", 400, 8),
                new Worker("Tihomir", "Todorov", 530, 8),
                new Worker("svetlin", "Mitev", 270 , 4),
                new Worker("Rumen"	, "Mihailov", 521, 8),
                new Worker("Rumen"	, "Dimitrov", 822, 8),
                new Worker("Valentino", "Krechev", 520 , 6),
                new Worker("Miroslav", "Yanakiev", 824, 8),
                new Worker("Kalin"	, "Ivanov", 320, 6),
                new Worker("Ivaylo", "Iliev", 428,8),
                new Worker("Niki"	, "Dimitrov ", 490,8),
            };
            List<Student> sortedStudents = students.OrderBy(x => x.Grade).ToList();
            Console.WriteLine("Sort students by grade");
            printToConsole<Student>(sortedStudents);
            List<Worker> sortedWorkers = workers.OrderByDescending(x => x.MoneyPerHour()).ToList();
            Console.WriteLine("\nSort workers by money per hour");
            printToConsole<Worker>(sortedWorkers);
            List<Human> mergedHumans = new List<Human>();
            foreach (var item in sortedStudents)
            {
                mergedHumans.Add(item);
            }
            foreach (var item in sortedWorkers)
            {
                mergedHumans.Add(item);
            }

            Console.WriteLine("\nMerge humans");
            printToConsole<Human>(mergedHumans);
            List<Human> sortedHumans = mergedHumans.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();
            Console.WriteLine("\nSort humans by names");
            printToConsole<Human>(sortedHumans);
        }
        public static void printToConsole<T>(IList<T> printList)
        {
            foreach (var item in printList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
