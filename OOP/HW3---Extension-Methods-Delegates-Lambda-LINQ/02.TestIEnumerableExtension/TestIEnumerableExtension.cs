using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.IEnumerableExtensions;

namespace _02.TestIEnumerableExtension
{
    class TestIEnumerableExtension
    {
        static void Main()
        {
            int[] arr = new int[] { 1, 5, 67, 88, 56, 24, 3, -43, 1, -5, 34, 4 };
            Console.WriteLine(arr.Sum());
            Console.WriteLine(arr.Product());
            Console.WriteLine(arr.Min());
            Console.WriteLine(arr.Max());
            Console.WriteLine(arr.Average());
            var human = new Human(1.56, "Ivan", 36);
            List<Human> humanList = new List<Human>()
            {
                new Human(1.86,"Ivan",26),
                new Human(1.66,"Pesho",25),
                new Human(1.78,"Petkan",63),
                new Human(1.92,"George",18),
                new Human(1.84,"Stoyan",19)
            };
            
            Console.WriteLine(humanList.Average(new CustomTypeNumericalValue<Human>(Human.GetHeight)));  // Method in delegate is set without parametars

            Console.WriteLine("Inline c# function");
            Console.WriteLine(humanList.Average(x => x.Height));
        }
    }

    public class Human :IComparable
    {
        public double Height { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Human(double height, string name, int age)
        {
            this.Height = height;
            this.Name = name;
            this.Age = age;
        }
        public static decimal GetHeight(Human h) // must be static
        {
            return (decimal)h.Height;
        }

        public int CompareTo(object obj)  // compare method must get object type
        {
            Human h = (Human)obj;
            return this.Height.CompareTo(h.Height);
        }


    }
}
