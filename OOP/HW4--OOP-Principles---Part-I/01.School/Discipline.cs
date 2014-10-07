namespace _01.School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Discipline : ICommentable
    {
        private int lectureNumbers;
        private int exerciseNumbers;

        public string Comment { get; set; }

        public string Name { get; set; }

        public int LectureNumbers
        {
            get { return this.lectureNumbers; }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("lectureNumbers must be larger than 0");
                }
                else
                {
                    this.lectureNumbers = value;
                }
            }
        }

        public int ExerciseNumbers
        {
            get { return this.exerciseNumbers; }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("exerciseNumbers must be larger than 0");
                }
                else
                {
                    this.exerciseNumbers = value;
                }
            }
        }
        
        // Constructor
        public Discipline(string name, int lectureNumbers, int exerciseNumbers)
        {
            this.Name = name;
            this.LectureNumbers = lectureNumbers;
            this.ExerciseNumbers = exerciseNumbers;
        }

        public override string ToString()
        {
            return String.Format("{0} - L{1}, E{2}", this.Name, this.LectureNumbers, this.ExerciseNumbers);
        }
    }
}
