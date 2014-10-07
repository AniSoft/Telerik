using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _05.BitArray64;

namespace _05TestBitArray64
{
    class TestBitArray64
    {
        static void Main()
        {
            BitArray64 bArr = new BitArray64(25684556);

            //Console.WriteLine(10010101101010100010);
            Console.WriteLine(bArr);
            bArr[8] = 1;
            Console.WriteLine(bArr);

            Console.WriteLine("Zero bit of number is {0}", bArr[0]);
            Console.WriteLine("Second bit of number is {0}", bArr[2]);
            int index = 0;
            foreach (int bit in bArr)
            {
                Console.WriteLine("Bit {0,2}: {1}", index, bit);
                index++;
            }
        }
    }
}
