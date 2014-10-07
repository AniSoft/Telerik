namespace GSMCallHistoryTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Defining_Classes___Part_I;

    class GSMCallHistoryTest
    {
        static void Main(string[] args)
        {
            // defining instance of GSM class
            GSM gsm = new GSM("Sony Ericson", "Sony", 250, "Pesho", new Battery("model1", 20, 5, BatteryType.Li_Ion), new Display(3, 256));

            // add few calls
            gsm.AddingCalls(new Call(DateTime.Now, "0886 872 656", 505));
            gsm.AddingCalls(new Call(DateTime.Now.AddMinutes(10.5), "0888 842 656", 3205));
            gsm.AddingCalls(new Call(DateTime.Now.AddMinutes(20.2), "0878 352 521", 1205));
            gsm.AddingCalls(new Call(DateTime.Now.AddMinutes(14.3), "0898 282 158", 805));

            // Print informacion about calls
            for (int i = 0; i < gsm.CallHistory.Count; i++)
            {
                Console.WriteLine(gsm.CallHistory[i]);
            }
            Console.WriteLine();

            // print total price if price is 0.37$
            double singlePrice = 0.37;
            double price;
            price = gsm.CalcTotalPrice(singlePrice);
            Console.WriteLine("Total price for calls that are {0}$ per minute is {1}$", singlePrice, price);

            // Remove longest call and print new price
            int index = findLongestCall(gsm.CallHistory);
            gsm.RemovingCalls(index);
            Console.WriteLine("Remove longest call and calculate new total price");
            price = gsm.CalcTotalPrice(singlePrice);
            Console.WriteLine("Total price for calls that are {0}$ per minute is {1}$", singlePrice, price);

            // Clear List of calls
            gsm.ClearCalls();
            
        }

        private static int findLongestCall(List<Call> calls)
        {
            int index = 0;
            int duration = -1;

            for (var i = 0; i < calls.Count; i++)
            {
                if (calls[i].Duration > duration)
                {
                    duration = calls[i].Duration;
                    index = i;
                }
            }

            return index;
        }
    }
}
