using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Student
{
    public class Student : ICloneable, IComparable
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string ssn;
        private string address;
        private string phoneNumber;
        private string email;
        private int? course;

        public Specialty SpecialtyName { get; set; }
        public Faculty FacultyName { get; set; }
        public University UniversityName { get; set; }
        
        public string FirstName
        {
            get
            {
                return firstName;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name cannot be null or empty.");
                }
                else
                {
                    firstName = value;
                }
            }
        }

        public string MiddleName
        {
            get
            {
                return middleName;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Middle name cannot be null or empty.");
                }
                else
                {
                    middleName = value;
                }
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name cannot be null or empty.");
                }
                else
                {
                    lastName = value;
                }
            }
        }

        public string SSN
        {
            get
            {
                return ssn;
            }
            set
            {
                int result = 0;
                if (value.Length != 10 && !int.TryParse(value, out result))
                {
                    throw new ArgumentException("SSN must be 10 digits.");
                }
                else
                {
                    ssn = value;
                }
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            private set
            {
                if (value == String.Empty)
                {
                    throw new ArgumentException("Address cannot be null or empty.");
                }
                else
                {
                    address = value;
                }
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                long result = 0;
                if (value != null && value.Length != 10 && !long.TryParse(value, out result))
                {
                    throw new ArgumentException("Phone number must be 10 digits.");
                }
                else
                {
                    phoneNumber = value;
                }
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (value == String.Empty)
                {
                    throw new ArgumentException("Email cannot be null or empty.");
                }
                else
                {
                    email = value;
                }
            }
        }

        public int? Course
        {
            get { return course; }
            set
            {

                if (value <= 0 || value > 5)
                {
                    throw new ArgumentException("Email cannot be null or empty.");
                }
                else
                {
                    course = value;
                }
            }
        }

        // Constructor
        public Student(string firstName, string middleName, string lastName, string ssn)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
        }
        public Student(string firstName, string middleName, string lastName, string ssn, string address, string phoneNumber,
            string email, int? course, Specialty specialtyName, Faculty facultyName, University universityName)
            : this(firstName, middleName, lastName, ssn)
        {
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Course = course;
            this.SpecialtyName = specialtyName;
            this.FacultyName = facultyName;
            this.UniversityName = universityName;
        }

        //Override methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Student:");
            sb.Append(String.Format("\nName: {0} {1} {2}",this.FirstName,this.MiddleName, this.LastName));
            sb.Append(String.Format("\nSSN: {0}", this.SSN));
            if (this.Address != null)
            {
                sb.Append(String.Format("\nAddress: {0}",this.Address));
            }
            if (this.PhoneNumber != null)
            {
                sb.Append(String.Format("\nPhoneNumber: {0}", this.PhoneNumber));
            }
            if (this.Email  != null)
            {
                sb.Append(String.Format("\nEmail: {0}", this.Email));
            }
            if (this.Course != null)
            {
                sb.Append(String.Format("\nCourse: {0}", this.Course));
            }
            if (this.UniversityName != University.None)
            {
                sb.Append(String.Format("\nUniversity: {0}", this.UniversityName));
            }
            if (this.FacultyName != Faculty.None)
            {
                sb.Append(String.Format("\nFaculty: {0}", this.FacultyName));
            }
            if (this.SpecialtyName != Specialty.None)
            {
                sb.Append(String.Format("\nSpeciality: {0}", this.SpecialtyName));
            }
            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hashCode = this.FirstName.GetHashCode() ^ this.LastName.GetHashCode() ^ this.SSN.GetHashCode();
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            Student st = obj as Student;
            if (st == null)
            {
                return false;
            }
            if (!Object.Equals(this.FirstName, st.FirstName))
            {
                return false;
            }
            if (!Object.Equals(this.LastName, st.LastName))
            {
                return false;
            }
            if (!Object.Equals(this.SSN, st.SSN))
            {
                return false;
            }
            return true;
        }
        public static bool operator ==(Student A, Student B)
        {
            return Student.Equals(A, B);
        }
        public static bool operator !=(Student A, Student B)
        {
            return !A.Equals(B);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Student Clone()
        {
            Student clone = new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN,
                this.Address, this.PhoneNumber, this.Email, this.Course, this.SpecialtyName, this.FacultyName, this.UniversityName);
            return clone;
        }

        public int CompareTo(object obj)
        {
            int result;
            Student student = obj as Student;
            if (student == null)
            {
                throw new ArgumentException("This object is not a Student.");
            }
            else
            {
                string thisFullName = this.FirstName + this.MiddleName + this.LastName;
                string studentFullName = student.FirstName + student.MiddleName + student.LastName;
                result = thisFullName.CompareTo(studentFullName);
                if (result == 0)
                {
                    result = this.SSN.CompareTo(student.SSN);
                }
                return result;
            }
        }
    }
}
