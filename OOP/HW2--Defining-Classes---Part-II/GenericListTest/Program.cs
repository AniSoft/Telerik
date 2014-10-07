using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericList;

namespace GenericListTest
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>();
            list.AddItem(5);
            list.AddItem(3);
            Console.WriteLine("{2,-20}   Capacity = {0}; Count = {1}", list.Capacity, list.Count, list);
            list.AddItem(7);
            list.AddItem(1);
            Console.WriteLine("{2,-20}   Capacity = {0}; Count = {1}", list.Capacity, list.Count, list);
            list.AddItem(2);
            Console.WriteLine("{2,-20}   Capacity = {0}; Count = {1}", list.Capacity, list.Count, list);

            Console.WriteLine();
            Console.WriteLine(list);
            list.InsertItem(3, 34);
            Console.WriteLine("{2,-20}   Capacity = {0}; Count = {1}", list.Capacity, list.Count, list);
            list.RemoveItem(2);
            Console.WriteLine("{2,-20}   Capacity = {0}; Count = {1}", list.Capacity, list.Count, list);

            Console.WriteLine("Min element in list: {0}", list.Min());
            Console.WriteLine("Max element in list: {0}", list.Max());

            list.Clear();

            // give error because is not IComparable interface
            //GenericList<NotIComparableClass> listOfNotIComparableClass = new GenericList<NotIComparableClass>();
        }
    }
}
