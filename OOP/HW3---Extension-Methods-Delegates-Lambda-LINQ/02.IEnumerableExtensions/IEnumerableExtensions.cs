using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.IEnumerableExtensions
{

    //delegate for the method which will be passed to retrieve the required numeral value
    //for executing the methods Sum, Average, Product for user defined types
    public delegate decimal CustomTypeNumericalValue<T>(T ob);

    public static class IEnumerableExtensions
    {
        //this version is for numeral types
        public static decimal Sum<T>(this IEnumerable<T> collection) where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            if (collection == null)
            {
                throw new ArgumentNullException("empty collection");
            }
            decimal sum = 0;
            foreach (T element in collection)
            {
                sum = sum + (dynamic)element;
            }
            return sum;
        }
        
        //this version is for user defined types (classes structures etc)
        public static decimal Sum<T>(this IEnumerable<T> collection, CustomTypeNumericalValue<T> numericalVal)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("empty collection");
            }
            decimal sum = 0;
            foreach (T element in collection)
            {
                sum = sum + numericalVal(element);
            }
            return sum;
        }
        public static decimal Product<T>(this IEnumerable<T> collection) where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            if (collection == null)
            {
                throw new ArgumentNullException("empty collection");
            }
            decimal sum = 1;
            foreach (T element in collection)
            {
                sum = sum * (dynamic)element;
            }
            return sum;
        }

        public static decimal Product<T>(this IEnumerable<T> collection, CustomTypeNumericalValue<T> numericalVal)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("empty collection");
            }
            decimal sum = 1;
            foreach (T element in collection)
            {
                sum = sum * numericalVal(element);
            }
            return sum;
        }
        public static decimal Average<T>(this IEnumerable<T> collection) where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            if (collection == null)
            {
                throw new ArgumentNullException("empty collection");
            }
            decimal sum = 0;
            long count = 0;
            foreach (T element in collection)
            {
                sum = sum + (dynamic)element;
                count++;
            }
            if (count == 0)
            {
                throw new ArgumentOutOfRangeException("Collection contains no elements");
            }
            else
            {
                return sum / count;
            }
        }

        public static decimal Average<T>(this IEnumerable<T> collection, CustomTypeNumericalValue<T> numericalVal)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("empty collection");
            }
            decimal sum = 0;
            long count = 0;
            foreach (T element in collection)
            {
                sum = sum + numericalVal(element);
                count++;
            }
            if (count == 0)
            {
                throw new ArgumentOutOfRangeException("Collection contains no elements");
            }
            else
            {
                return sum / count;
            }
        }
        public static T Min<T>(this IEnumerable<T> collection) where T : IComparable
        {
            if (collection == null)
            {
                throw new ArgumentNullException("empty collection");
            }
            return collection.OrderByDescending(x => x).First();
        }
        public static T Max<T>(this IEnumerable<T> collection) where T : IComparable
        {
            if (collection == null)
            {
                throw new ArgumentNullException("empty collection");
            }
            return collection.OrderBy(x => x).First();
        }

 
    }
}
