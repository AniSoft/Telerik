namespace _01.School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Person : ICommentable
    {
        public string Name { get; set; }
        public string Comment { get; set; }

        // Constructor
        public Person(string name)
        {
            this.Name = name;
        }
    }
}
