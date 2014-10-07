namespace _3DPoint
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class DistanceIn3D
    {
        private Point3D firstPoint;
        private Point3D secondPoint;

        public Point3D FirstPoint
        {
            get { return firstPoint; }
            set { firstPoint = value; }
        }

        public Point3D SecondPoint
        {
            get { return secondPoint; }
            set { secondPoint = value; }
        }

        public double CalcDistance(Point3D firstPoint, Point3D secondPoint)
        {
            return Math.Round(Math.Sqrt(Math.Pow(secondPoint.X - firstPoint.X,2) + Math.Pow(secondPoint.Y - firstPoint.Y,2) + Math.Pow(secondPoint.Z - firstPoint.Z,2)),2);
        }
        
    }
}
