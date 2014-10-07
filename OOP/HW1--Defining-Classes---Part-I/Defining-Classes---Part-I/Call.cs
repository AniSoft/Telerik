using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defining_Classes___Part_I
{
    public class Call
    {
        //Properties
        public DateTime Date { get; set; }
        public string DialedPhoneNumber { get; set; }
        public int Duration { get; set; }

        //Constructors
        public Call(DateTime date, string dialedPhoneNumber, int duration)
        {
            this.Date = date;
            this.DialedPhoneNumber = dialedPhoneNumber;
            this.Duration = duration;
        }
        public override string ToString()
        {
            string result = String.Format("Call: {0} | {1} | {2} | {3} sec", this.Date.ToString("dd.MM.yy"), this.Date.ToString("HH:mm:ss"), this.DialedPhoneNumber, this.Duration);

            return result;
        }
    }
}
