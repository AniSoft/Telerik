namespace _3DPoint
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;

    public static class PathStorage
    {
        private static List<Path> pathList;

        static PathStorage()
        {
            pathList = new List<Path>();
        }

        public static void SaveToFile(List<Path> pathList, string filepath)
        {
            StreamWriter sw = new StreamWriter(filepath);
            StringBuilder sb = new StringBuilder();

            foreach (var path in pathList)
            {
                foreach (var item in path.Pathlist)
                {
                    sb.Append(String.Format("{0},{1},{2}|", item.X, item.Y, item.Z));
                }
                sw.WriteLine(sb.ToString());
                sb.Clear();
            }
            sw.Close();
        }

        public static List<Path> LoadFromFile(string filepath)
        {
            StreamReader sr = new StreamReader(filepath);
            string row = sr.ReadLine();
            Point3D point = new Point3D();
            
            while (row != null)
            {
                Path path = new Path();
                string[] paths = row.Split(new char[]{'|'}, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in paths)
                {
                    double x, y, z;
                    string[] coordinates = item.Split(',');
                    if (coordinates.Length == 3 && double.TryParse(coordinates[0], out x)
                        && double.TryParse(coordinates[1], out y) && double.TryParse(coordinates[2], out z))
                    {
                        point.X = x;
                        point.Y = y;
                        point.Z = z;
                        path.Add(point);
                    }
                }
                pathList.Add(path);
                //path.Clear();

                row = sr.ReadLine();
            }

            return pathList;
        }
    }
}
