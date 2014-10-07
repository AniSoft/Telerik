using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.ShapeClass;

namespace _01.TestShapeClass
{
    class TestShapeClass
    {
        static void Main()
        {
            List<Shape> shapes = new List<Shape>()
            {
                new Rectangle(5,5),
                new Triangle(5,5),
                new Circle(5)
            };
            foreach (var item in shapes)
            {
                Console.WriteLine("{0} has surface {1:F3}", item.GetType().Name, item.CalculateSurface());
            }
        }
    }
}
