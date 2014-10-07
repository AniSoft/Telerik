namespace _01.School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StudentClass : ICommentable
    {
        public List<Student> StudentSet { get; set; }

        public List<Teacher> TeacherSet { get; set; }

        public string TextIdentifier { get; set; }

        public string Comment { get; set; }

        // Constructor
        public StudentClass(string textIdentifier)
        {
            this.TextIdentifier = textIdentifier;
            this.StudentSet = new List<Student>();
            this.TeacherSet = new List<Teacher>();
        }

        public StudentClass(string textIdentifier, List<Student> studentSet, List<Teacher> teacherSet)
        {
            this.TextIdentifier = textIdentifier;
            this.StudentSet = studentSet;
            this.TeacherSet = teacherSet;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format("Class '{0}'",TextIdentifier));
            sb.Append("\nSet of students:\n");

            foreach (var item in StudentSet)
            {
                sb.Append(item + ";\n");
            }
            sb.Remove(sb.Length - 3, 3);
            sb.Append("\nSet of teachers:\n");

            foreach (var item in TeacherSet)
            {
                sb.Append(item + ";\n");
            }
            sb.Remove(sb.Length - 3, 3);

            return sb.ToString();
        }
    }
}
