using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank
{
    public class LoanAccount : Account
    {
        // Constructor
        public LoanAccount(Customer customer, double monthInterestRate, double balance = 0)
            : base(customer, monthInterestRate, balance)
        {
        }

        public override double CalculateInterestAmount(int numberOfMonths)
        {
            if (this.customer is Person && numberOfMonths > 3)
            {
                return (numberOfMonths - 3) * MonthInterestRate;
            }
            if (this.customer is Company && numberOfMonths > 2)
            {
                return (numberOfMonths - 2) * MonthInterestRate;
            }
            return 0;
        }
    }
}
