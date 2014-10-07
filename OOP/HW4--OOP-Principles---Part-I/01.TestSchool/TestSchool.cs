using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.School;

namespace _01.TestSchool
{
    class TestSchool
    {
        static void Main(string[] args)
        {
            Discipline Math = new Discipline("Math", 6, 10);
            Discipline Geography = new Discipline("Geography", 2, 2);
            Discipline History = new Discipline("History", 2, 2);
            Discipline BulgarianLanguage = new Discipline("BulgarianLanguage", 4, 6);
            Discipline EnglishLanguage = new Discipline("EnglishLanguage", 6, 8);
            Discipline Biology = new Discipline("Biology", 2, 2);

            Teacher teacherSvetla = new Teacher("Svetla Velikova");
            teacherSvetla.DisciplineSet.Add(Geography);
            teacherSvetla.DisciplineSet.Add(History);
            teacherSvetla.DisciplineSet.Add(Biology);
            Console.WriteLine(teacherSvetla);
            Teacher teacherRumen = new Teacher("Rumen Mihailov");
            teacherRumen.DisciplineSet.Add(BulgarianLanguage);
            teacherRumen.DisciplineSet.Add(Math);
            Console.WriteLine(teacherRumen);
            Teacher teacherKalin = new Teacher("Kalin Ivanov");
            teacherKalin.DisciplineSet.Add(EnglishLanguage);
            Console.WriteLine(teacherKalin);

            StudentClass ClassA = new StudentClass("A");
            ClassA.TeacherSet.Add(teacherKalin);
            ClassA.TeacherSet.Add(teacherRumen);
            ClassA.TeacherSet.Add(teacherSvetla);
            ClassA.StudentSet.Add(new Student("Ivaylo Iliev",600501));
            ClassA.StudentSet.Add(new Student("Niki Dimitrov", 601501));
            ClassA.StudentSet.Add(new Student("Diyana Dobreva", 600301));
            ClassA.StudentSet.Add(new Student("Jana Kazarova",600222));
            ClassA.StudentSet.Add(new Student("Damian Apostolov", 604710));
            Console.WriteLine(ClassA);

            StudentClass ClassB = new StudentClass("B",
                new List<Student>()
                {
                    new Student("Hrisi Dimitrova", 202580),
                    new Student("Diyana Dobreva", 236656),
                    new Student("Nina Nikolova", 336545),
                    new Student("Marita Mileva",636565),
                    new Student("Gergana Georgieva", 465650),
                    new Student("Tihomir Todorov", 534365),
                    new Student("svetlin Mitev", 456417),
                    new Student("Valentino Krechev", 525645),
                    new Student("Miroslav Yanakiev", 265254),
                    new Student("Ivaylo Iliev", 284565),
                    new Student("Damian Stoyanov"  , 245653),
                    new Student("Liubomir Slavchev", 565640),
                },
                new List<Teacher>()
                {
                    new Teacher("Svetla Velikova"),
                    new Teacher("Rumen Mihailov"),
                    new Teacher("Kalin Ivanov")
                });
            Console.WriteLine(ClassB);



        }
    }
}
