namespace _3DPoint
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            // Test task 1
            Point3D p = new Point3D();
            p.X = 4;
            p.Y = 3;
            Console.WriteLine(p.ToString());

            // Test task 2
            Console.WriteLine(p.ZeroPoint);

            // Test task 3
            DistanceIn3D dist = new DistanceIn3D();
            Console.WriteLine(dist.CalcDistance(p,p.ZeroPoint));
            Point3D p2 = new Point3D(4, 6, 2);
            Console.WriteLine(dist.CalcDistance(p,p2));

            // Test task 4
            Path path = new Path();
            path.Add(p);
            path.Add(0, p2);
            path.Add(new Point3D(9, 5, 9));
            path.Add(new Point3D(4, -6, -3));
            path.Add(3,new Point3D(2, -5, 8));
            List<Path> paths = new List<Path>();
            paths.Add(path);

            Path secondPath = new Path();
            secondPath.Add(new Point3D(1, 2, -7));
            secondPath.Add(p2);
            secondPath.Add(0, p);
            secondPath.Add(new Point3D(-4, 4, -3));
            secondPath.Add(2, new Point3D(3, 6, 9));
            paths.Add(secondPath);
            PathStorage.SaveToFile(paths, @"../../File with Path.txt");
            List<Path> loadedPaths = PathStorage.LoadFromFile(@"../../File with Path.txt");
            Console.WriteLine("Paths for save");
            printPaths(paths);
            Console.WriteLine("Loaded paths");
            printPaths(loadedPaths);
            
        }

        private static void printPaths(List<Path> paths)
        {
            foreach (var item in paths)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
