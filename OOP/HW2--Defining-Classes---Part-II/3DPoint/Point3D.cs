namespace _3DPoint
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public struct Point3D
    {
        // Fields
        private double x;
        private double y;
        private double z;
        private static readonly Point3D zeroPoint = new Point3D(0, 0, 0);

        /* 
         private static readonly Point3D zeroPoint;
         or with static constructor
         static Point3D()
        {
            zeroPoint = new Point3D(0, 0, 0);
        }*/

        // Properties
        public double X
        {
            get
            {
                return this.x;
            }

            set { this.x = value; }
        }

        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public double Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        public Point3D ZeroPoint
        {
            get { return zeroPoint; }
        }

        // Constructor
        public Point3D(int x, double y, double z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        // Methods
        public override string ToString()
        {
            return "{" + String.Format("{0},{1},{2}", X, Y, Z) + "}";
        }
    }
}
