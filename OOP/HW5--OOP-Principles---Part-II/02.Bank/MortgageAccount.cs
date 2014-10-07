namespace _02.Bank
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MortgageAccount : Account
    {
        // Constructor
        public MortgageAccount(Customer customer, double monthInterestRate, double balance = 0)
            : base(customer, monthInterestRate, balance)
        {
        }

        public override double CalculateInterestAmount(int numberOfMonths)
        {
            if (this.customer is Person && numberOfMonths > 6)
            {
                return (numberOfMonths - 6) * MonthInterestRate;
            }

            if (this.customer is Company)
            {
                if (numberOfMonths > 12)
                {
                    return numberOfMonths * MonthInterestRate;
                }
                else
                {
                    return 0.5 * numberOfMonths * MonthInterestRate;
                }
            }

            return 0;
        }
    }
}
