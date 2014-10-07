using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank
{
    public class DepositeAccount : Account
    {
        // Constructor
        public DepositeAccount(Customer customer, double monthInterestRate, double balance = 0)
            : base(customer, monthInterestRate, balance)
        {
        }

        public void WithdrawMoney(double money)
        {
            if (money <= 0)
            {
                throw new ArgumentOutOfRangeException("Withdrawed money must be positive number");
            }
            else if (this.Balance < money)
            {
                throw new ArgumentException("Not enough money.");
            }
            else
            {
                Balance -= money;
            }
        }

        public override double CalculateInterestAmount(int numberOfMonths)
        {
            if (this.Balance >= 1000)
            {
                return numberOfMonths * MonthInterestRate;
            }
            return 0;
        }
    }
}
