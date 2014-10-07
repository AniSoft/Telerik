using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.Student;

namespace _01TestStudent
{
    class TestStudent
    {
        static void Main()
        {
            List<Student> studentList = new List<Student>() {
            new Student("Stoyan", "Ivanov", "Petrov", "8506148485"),
            new Student("Stoyan", "Ivanov", "Petrov", "8506148485", "bul. Maria Luiza N25", "0885698651",
                "stoyanpet@abv.bg", 2, Specialty.ASPEngineer, Faculty.Engineer, University.TU),
            new Student("Stoyan", "Ivanov", "Petrov", "7608128816"),
            new Student("Ivan", "Ivanov", "Georgiev", "9608152138")
            };
            foreach (var item in studentList)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine(studentList[0].Equals(studentList[1]));
            Console.WriteLine(studentList[0] != studentList[2]);
            Console.WriteLine(studentList[0] == studentList[3]);

            Student cloneStudent = studentList[0].Clone();
            Console.WriteLine("Clone of the first student:");
            Console.WriteLine(cloneStudent);

            Console.WriteLine();
            Console.WriteLine("Compare two students");
            studentList.Sort();
            foreach (var item in studentList)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
        }
    }
}
