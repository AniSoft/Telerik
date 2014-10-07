namespace _02.Bank
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Company : Customer
    {
        private int companyID;

        public int CompanyID
        {
            get { return companyID; }

            set
            {
                if (value.ToString().Length != 8)
                {
                    throw new ArgumentOutOfRangeException("Personal ID must be 8 digits");
                }
                else
                {
                    companyID = value;
                }
            }
        }

        public Company(string name, string address, int companyID)
            :base(name, address)
        {
            this.CompanyID = companyID;
        }
    }
}
