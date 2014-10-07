namespace VersionAttribute
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [AttributeUsage(AttributeTargets.Struct |
        AttributeTargets.Class | 
        AttributeTargets.Interface |
        AttributeTargets.Enum |
        AttributeTargets.Method, 
        AllowMultiple = false)]

    public class VersionAttribute : System.Attribute
    {
        public int MajorVersion { get; private set; }
        public int MinorVersion { get; private set; }
        public string Coment { get; private set; }

        public VersionAttribute(int major, int minor, string comment)
        {
            this.MajorVersion = major;
            this.MinorVersion = minor;
            this.Coment = comment;
        }

        public VersionAttribute(int major, int minor) : this(major, minor, String.Empty)
        {            
        }
    }
}
