namespace _02.TestBank
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using _02.Bank;

    class TestBank
    {
        static void Main()
        {
            List<Customer> customers = new List<Customer>()
            {
                new Person("Владислав Александров Спасов", "ул. \"Гео Милев\" No 18", 5145115654),
                new Company("ДЕБА-98 ET", "ул. \"Хан Омуртаг\" No84", 89487898),
                new Person("Тодор Василев Витков","бул. \"Цариградско шосе\" No 85 бл.109",8012058075),
                new Person("Румен Димитров Александров","ул. \"Любен Каравелов\" No25", 8501258565),
                new Company("МЕТРО ТУРИЗЪМ ООД","кв. Горубляне - ул- \"Самоковско шосе\" No36", 12548565),
                new Company("СИЛВИЯ-2002 ЕООД","ул.\"Ген. Гурко\" No 32", 65328564),
                new Person("Росица Петрова Виделова","с. Лозен - ул. \"Съединение\" No116",7509168798),
                new Company("ВМТ ОРБИТА АД","бул. \"Г.М.Димитров\" No54", 98781568),
                new Person("Ирина Николова Гринкевич","ул.\"Ген. Гурко\" No 6", 9004158978),
                new Company("БЪЛГЕРИАН ВИП ТУРС ООД","ул.\"Ген. Гурко\" No 46", 98752932),
            };
            
            List<Account> accounts = new List<Account>()
            {
                new DepositeAccount(customers[0],0.568,1500),
                new LoanAccount(customers[4],0.868,2500),
                new DepositeAccount(customers[6],0.325,500),
                new LoanAccount(customers[8],0.698,15000),
                new DepositeAccount(customers[9],0.785,1800),
                new LoanAccount(customers[7],0.366,6500),
                new DepositeAccount(customers[3],0.871,9300),
                new DepositeAccount(customers[5],0.458,1200),
                new MortgageAccount(customers[4],0.683,10500),
                new MortgageAccount(customers[2],0.482,3500),
            };
            Random rand = new Random();

            foreach (var item in accounts)
            {
                int months = rand.Next(1, 16);
                Console.WriteLine("{0} has {1:C2}, with MIRate {2} has {3:C2} for {4} months", item.customer.Name,item.Balance,item.MonthInterestRate, item.CalculateInterestAmount(months), months);
            }
        }
    }
}
