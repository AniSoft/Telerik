using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class Teacher : Person
    {
        public List<Discipline> DisciplineSet { get; private set; }
       
        // Constructor
        public Teacher(string name)
            : base(name)
        {
            this.DisciplineSet = new List<Discipline>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Name);
            sb.Append(" Disciplines - ");
            foreach (var item in DisciplineSet)
            {
                sb.Append(item + "; ");
            }
            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }
        
    }
}
