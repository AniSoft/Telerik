namespace _07.TimerUsingDelegate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    class TestTimer
    {
        static void Main(string[] args)
        {
            TimerUsingDelegate t = new TimerUsingDelegate(TimerPrinting, 2);
            Thread timerThread = new Thread(new ThreadStart(t.StartTimer));
            timerThread.Start();
            
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("number:" + i);
            }
            t.StopTimer();
            Console.WriteLine("no timer");

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("number:" + i);
            }
        }

        public static void TimerPrinting()
        {
            Console.WriteLine("I am delegate and print myself at some interval");
        }
    }
}
