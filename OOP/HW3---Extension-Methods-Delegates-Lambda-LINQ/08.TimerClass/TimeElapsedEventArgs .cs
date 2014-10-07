namespace _07.TimerUsingDelegate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    // A delegate which processes the TimeElapsed event.
    public delegate void TimeElapsedEventHandler(object sender, TimeElapsedEventArgs e);

    /// A class which inherits System.EventArgs and keeps information for the ticks left
    public class TimeElapsedEventArgs : EventArgs
    {
        private int ticksLeft;

        public int TicksLeft
        {
            get
            {
                return this.ticksLeft;
            }
        }

        public TimeElapsedEventArgs(int ticksLeft)
        {
            this.ticksLeft = ticksLeft;
        }
    }
}
