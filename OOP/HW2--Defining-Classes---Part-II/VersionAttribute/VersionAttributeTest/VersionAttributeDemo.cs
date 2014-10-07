using System;
using System.Reflection;
using VA = VersionAttribute;

namespace VersionAttributeTest
{
    [VA.Version(2, 0,"Version demo class")]
    class VersionAttributeDemo
    {
        [VA.Version(3,1)]
        private enum EnumerationDemo
        {
            Write = 0,
            Read = 1,
        }

        [VA.Version(1,3, "A demo method")]
        private static void DoNothing()
        {
        }

        [VA.Version(6,4)]
        private static bool IsnumberPositive(int n)
        {
            if (n > 0)
                return true;
            else
                return false;
        }

        static void Main()
        {
            // print class attribute
            Type type = typeof(VersionAttributeDemo);
            object[] classAttributes = type.GetCustomAttributes(false);
            foreach (VA.VersionAttribute attr in classAttributes)
            {
                if (attr.Coment == String.Empty)
                {
                    Console.WriteLine("{2}: {0}.{1}", attr.MajorVersion, attr.MinorVersion, "Class version is");
                }
                else
                {
                    Console.WriteLine("{2}: {0}.{1}", attr.MajorVersion, attr.MinorVersion, attr.Coment);
                }
            }
            // print enumeration attribute
            Type enumType = type.GetNestedType("EnumerationDemo", BindingFlags.NonPublic);
            object[] EnumerationDemoAttributes = enumType.GetCustomAttributes(false);
            foreach (VA.VersionAttribute attr in EnumerationDemoAttributes)
            {
                if (attr.Coment == String.Empty)
                {
                    Console.WriteLine("{2}: {0}.{1}", attr.MajorVersion, attr.MinorVersion, "Enumeration version is");
                }
                else
                {
                    Console.WriteLine("{2}: {0}.{1}", attr.MajorVersion, attr.MinorVersion, attr.Coment);
                }
            }

            // print method attribute
            MethodInfo[] methods = type.GetMethods(BindingFlags.Static | BindingFlags.NonPublic);

            foreach (MethodInfo method in methods)
            {
                object[] methodAttributes = method.GetCustomAttributes(false);
                foreach (VA.VersionAttribute attr in methodAttributes)
                {
                    if (attr.Coment == String.Empty)
                    {
                        Console.WriteLine("{2}: {0}.{1}", attr.MajorVersion, attr.MinorVersion, "Method version is");
                    }
                    else
                    {
                        Console.WriteLine("{2}: {0}.{1}", attr.MajorVersion, attr.MinorVersion, attr.Coment);
                    }
                }
            }



        }
    }
}
