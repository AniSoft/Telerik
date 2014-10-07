using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ShapeClass
{
    public class Circle : Shape
    {
        //Constructor
        public Circle(double radius)
            : base(radius, radius)
        {
        }
        public override double CalculateSurface()
        {
            return Math.PI * this.Height * this.Height;
        }
    }
}
