using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _06.DevideBy7and3ArrayExtension;

namespace _06.TestDevideBy7and3ArrayExtension
{
    class DevideBy7and3ArrayExtension
    {
        static void Main(string[] args)
        {
            int[] intarray = new int[] {5, 6, 42, 67, 231, 54, 147, 44, 76, 252, 585 };

            int[] resultLambda = intarray.DevideBy7and3ArrayItemsLambda();
            Console.WriteLine(String.Join(",",resultLambda.Select(x => x.ToString()).ToArray()));

            int[] resultLINQ = intarray.DevideBy7and3ArrayItemsLINQ();
            Console.WriteLine(String.Join(",", resultLINQ.Select(x => x.ToString()).ToArray()));
        }

 

    }
}
