namespace _02.Bank
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Customer
    {
        private string name;
        private string address;

        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
                name = value;
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
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Address cannot be null or empty.");
                }
                address = value;
            }
        }

        public Customer(string name, string address)
        {
            this.Name = name;
            this.Address = address;
        }
    }
}
