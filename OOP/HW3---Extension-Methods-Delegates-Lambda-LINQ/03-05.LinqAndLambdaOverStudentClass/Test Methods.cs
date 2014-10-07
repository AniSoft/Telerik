namespace _03_05.LinqAndLambdaOverStudentClass
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
            {
                new Student("Svetla", "Velikova", 32),
                new Student("Kristina", "Ivanova", 18),
                new Student("Jana"	, "Kazarova", 52),
                new Student("Hrisi"	, "Dimitrova", 20),
                new Student("Diyana", "Dobreva", 23),
                new Student("Nina"	, "Nikolova", 33),
                new Student("Marita", "Mileva",63),
                new Student("Gergana", "Georgieva", 40),
                new Student("Tihomir", "Todorov", 53),
                new Student("svetlin", "Mitev", 47),
                new Student("Rumen"	, "Mihailov", 51),
                new Student("Stoqn"	, "Dimitrov", 22),
                new Student("Valentino", "Krechev", 52),
                new Student("Miroslav", "Yanakiev", 24),
                new Student("Kalin"	, "Ivanov", 32),
                new Student("Ivaylo", "Iliev", 28),
                new Student("Niki"	, "Dimitrov ", 49),
                new Student("Damian", "Stoyanov"  , 23),
                new Student("Liubomir", "Slavchev", 40),
                new Student("Damian", "Apostolov"  , 22)
            };

            Console.WriteLine("Print All students:");
            PrintToConsole(students);

            List<Student> filterStudents = FindAllStudetnsWhichFirstNameIsBeforeLastName(students);
            Console.WriteLine("\nPrint All students whose first name is before its last name alphabetically:");
            PrintToConsole(filterStudents);

            List<Student> youngStudents = studentsBetween18_24(students);
            Console.WriteLine("\nPrint All students with age between 18 and 24:");
            PrintToConsole(youngStudents);

            List<Student> lambdaSorted = students.OrderByDescending(st => st.FirstName).ThenByDescending(st => st.LastName).ToList();
            Console.WriteLine("\nPrint All students sorted in descending order with lambda:");
            PrintToConsole(lambdaSorted);

            List<Student> LINIQSorted = 
                (from st in students
                orderby  st.FirstName descending, st.LastName descending
                select st).ToList();
            Console.WriteLine("\nPrint All students sorted in descending order with LINIQ:");
            PrintToConsole(LINIQSorted);
        }

        private static List<Student> studentsBetween18_24(List<Student> students)
        {
            var queryStudents =
                from st in students
                where st.Age> 18 && st.Age < 24
                select st;
            return queryStudents.ToList(); 
        }

        private static void PrintToConsole(List<Student> filterStudents)
        {
            foreach (var item in filterStudents)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static List<Student> FindAllStudetnsWhichFirstNameIsBeforeLastName(List<Student> students)
        {
            List<Student> newstudents = new List<Student>();
            var queryStudents =
                from st in students
                where st.FirstName.CompareTo(st.LastName) < 0
                select st;

            foreach (var st in queryStudents)
            {
                newstudents.Add(st);
            }
            return newstudents; 
        }
    }
}
