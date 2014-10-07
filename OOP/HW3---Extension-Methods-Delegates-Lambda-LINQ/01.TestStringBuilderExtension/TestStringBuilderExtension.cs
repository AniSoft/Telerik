namespace _01.TestStringBuilderExtension
{
    using System;
    using System.Text;
    using _01.StringBuilderExtantion;

    class TestStringBuilderExtension
    {
        static void Main()
        {
            string str = "testing string";
            StringBuilder sb = new StringBuilder();
            sb.Append(str);
            StringBuilder subsb = sb.Substring(4, 7);
            Console.WriteLine(subsb.ToString());
            Console.WriteLine(str.Substring(4, 7));
            Console.WriteLine(sb.Substring(5));
        }
    }
}
