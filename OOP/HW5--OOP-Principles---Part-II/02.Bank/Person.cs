namespace _02.Bank
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Person : Customer
    {
        private long personalID;

        public long PersonalID
        {
            get { return personalID; }

            set
            {
                if (value.ToString().Length != 10)
                {
                    throw new ArgumentOutOfRangeException("Personal ID must be 10 digits");
                }
                else
                {
                    personalID = value;
                }
            }
        }

        public Person(string name, string address, long personalID)
            :base(name, address)
        {
            this.PersonalID = personalID;
        }
    }
}
