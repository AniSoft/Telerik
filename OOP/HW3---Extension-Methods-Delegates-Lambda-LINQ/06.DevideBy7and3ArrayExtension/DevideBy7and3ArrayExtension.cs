using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.DevideBy7and3ArrayExtension
{
    public static class DevideBy7and3ArrayExtension
    {
        public static int[] DevideBy7and3ArrayItemsLambda(this int[] array)
        {
            return array.Where(x => x % 7 ==  0 && x % 3 == 0).ToArray();
        }
        public static int[] DevideBy7and3ArrayItemsLINQ(this int[] array)
        {
            return (from item in array where item % 7 == 0 && item % 3 == 0 select item).ToArray();
        }
    }
}
