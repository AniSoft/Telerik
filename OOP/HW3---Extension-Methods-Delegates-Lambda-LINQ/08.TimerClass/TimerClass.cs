namespace _07.TimerUsingDelegate
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    public class TimerClass
    {
        // The event that will be raised when time elapses
        public event TimeElapsedEventHandler TimeElapsed;
        private int interval = 0;
        private bool stopper = true;

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

        protected void OnTimeElapsed(int counter)
        {
            if (TimeElapsed != null)
            {
                TimeElapsedEventArgs e = new TimeElapsedEventArgs(counter);
                TimeElapsed(this, e);
            }
        }

        public TimerClass(int interval)
        {
            this.interval = interval;
        }
        
        public void StartTimer()
        {
            int counter = 0;
            stopper = false;
        
            while (stopper == false)
            {
                Thread.Sleep(this.interval);
                if (stopper == false)
                {
                    OnTimeElapsed(counter);
                    counter++;
                }
            }
        }
        
        public void StopTimer()
        {
            stopper = true;
        }
    }
}
