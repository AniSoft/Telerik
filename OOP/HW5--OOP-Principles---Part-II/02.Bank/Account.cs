namespace _02.Bank
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Account : ICalculetable
    {
        private double balance;
        private double monthInterestRate;
        public Customer customer { get; protected set; }

        public double Balance
        {
            get { return balance; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Account balance must be positive number or zero");
                }
                else
                {
                    balance = value;
                }
            }
        }

        public double MonthInterestRate
        {
            get { return monthInterestRate; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Account balance must be positive number or zero");
                }
                else
                {
                    monthInterestRate = value;
                }
            }
        }

        // Constructor
        public Account(Customer customer, double monthInterestRate, double balance = 0)
        {
            this.customer = customer;
            this.MonthInterestRate = monthInterestRate;
            this.Balance = balance;
        }

        public virtual void DepositeMoney(double money)
        {
            if (money <= 0)
            {
                throw new ArgumentOutOfRangeException("Deposited money must be positive number");
            }
            else
            {
                Balance += money;
            }
        }

        public virtual double CalculateInterestAmount(int numberOfMonths)
        {
            return numberOfMonths * MonthInterestRate;
        }
    }
}
