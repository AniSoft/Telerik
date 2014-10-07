using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07.TimerUsingDelegate
{
    public delegate void TimerElapsed(); // declarate delegate

    public class TimerUsingDelegate
    {
        private int interval = 0;
        private TimerElapsed callback;
        private bool stopper = true;
        private Action method;

        public int Interval
        {
            get
            {
                return interval;
            }
            set
            {
                interval = value;
            }
        }

        public TimerUsingDelegate(Action method, int interval)
        {
            this.interval = interval;
            this.method = method;
        }
        public void StartTimer()
        {

            stopper = false;
            this.callback = new TimerElapsed(method); // initialize delegate
            while (stopper == false)
            {
                Thread.Sleep(this.interval);
                if (stopper == false)
                {
                    callback(); // use delegate
                }
            }


        }
        public void StopTimer()
        {
            stopper = true;
        }
    }
}
