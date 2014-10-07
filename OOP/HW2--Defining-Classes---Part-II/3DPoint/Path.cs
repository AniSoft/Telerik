using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DPoint
{
    public class Path
    {
        private readonly List<Point3D> pathlist = new List<Point3D>();

        public List<Point3D> Pathlist
        {
            get { return this.pathlist; }
        }
        
        public void Add(Point3D point)
        {
            Add(pathlist.Count, point);
        }

        public void Add(int index, Point3D point)
        {
            if (index < pathlist.Count)
            {
                pathlist.Insert(index, point);
            }
            else
            {
                pathlist.Add(point);
            }
        }
        public void Clear()
        {
            pathlist.Clear();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in pathlist)
            {
                sb.Append(item.ToString());
                sb.Append(" | ");
            }
            sb.Remove(sb.Length - 3, 3);
            return sb.ToString();
        }
    }
}
