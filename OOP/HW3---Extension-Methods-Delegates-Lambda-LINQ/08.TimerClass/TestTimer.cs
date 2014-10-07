using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07.TimerUsingDelegate
{
    class TestTimer
    {
        static void Main(string[] args)
        {
            TimerClass t = new TimerClass(2);
            t.TimeElapsed += new TimeElapsedEventHandler(TimerPrinting);
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

        public static void TimerPrinting(object sender, TimeElapsedEventArgs e)
        {
            Console.WriteLine("I am delegate and print myself at some interval");
        }
    }
}
