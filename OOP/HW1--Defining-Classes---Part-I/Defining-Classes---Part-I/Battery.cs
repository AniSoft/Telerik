namespace Defining_Classes___Part_I
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public enum BatteryType
    {
        Li_Ion, NiMH, NiCd
    }

    public class Battery
    {
        //Fields
        private string model;
        private double hoursIdle;
        private double hoursTalk;
        private BatteryType type;

        //Properties
        public string Model
        {
            get { return this.model; }
            set 
            {
                if (value != String.Empty)
                {
                    this.model = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("model","Model can't be Empty Text!");
                }
            }
        }
        
        public double HoursIdle 
        {
            get { return this.hoursIdle; }
            
            set
            {
                if (value >= 0)
                {
                    this.hoursIdle = value;
                }
                else
                { 
                    throw new ArgumentOutOfRangeException("hoursIdle","HoursIdle can't be negative!");
                }
            }
        }

        public double HoursTalk
        {
            get { return this.hoursTalk; }
            
            set
            {
                if (value >= 0)
                {
                    this.hoursTalk = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("hoursTalk", "HoursTalk can't be negative!");
                }
            }
        }
        
        public BatteryType Type
        {
            get { return this.type; }
        }

        //Constructors
        public Battery()
        {
        }
        
        public Battery(string model, int hoursIdle, int hoursTalk, BatteryType type)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.type = type;
        }
    }
}
