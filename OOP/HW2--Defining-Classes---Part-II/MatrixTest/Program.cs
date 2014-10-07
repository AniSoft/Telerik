using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix;

namespace MatrixTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix<int> m1 = new Matrix<int>(new[,] { { 5, 6, 7, 3 }, { -5, 3, 5, -5 }, { 2, 3, -7, 1 }, { 9, 0, -2, -3 } });
            Matrix<int> m2 = new Matrix<int>(new[,] { { 6, 3, 1, 4 }, { -3, -9, 2, 1 }, { -6, 2, -2, -3 }, { 6, 6, -7, 4 } });
            Console.WriteLine("Matrix m1");
            Console.WriteLine(m1);
            Console.WriteLine("Matrix m2");
            Console.WriteLine(m2);
            Console.WriteLine("m1 + m2");
            Console.WriteLine(m1 + m2);
            Console.WriteLine("m1 - m2");
            Console.WriteLine(m1 - m2);
            Console.WriteLine("m1 * m2");
            Console.WriteLine(m1 * m2);

            if (m1)
            {
                Console.WriteLine("m1 have NonNull items ");
            }
            Matrix<double> doubleMatrix = new Matrix<double>(3, 4);
            if (!doubleMatrix)
            {
                Console.WriteLine("doubleMatrix have only Null items ");
            }
        }
    }
}
