using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defining_Classes___Part_I
{
    public class GSM
    {
        //fields
        private string model;
        private string manufacturer;
        private double price;
        private string owner;
        private Battery battery = new Battery();
        private Display display = new Display();
        // define static field for iPhone4S
        private static GSM iPhone4S = new GSM("IPhone4S", "IPhone")
        {
            Price = 550,
            Owner = "Petkan",
            GsmBattery = new Battery("model6", 18, 6, BatteryType.NiMH),
            GsmDisplay = new Display(7, 1024)
        };
        private List<Call> callHistory;

        //Properties
        public string Model
        {
            get { return this.model; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    this.model = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("model","Model can't be Empty Text!");
                }
            }
        }
        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    this.manufacturer = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("manufacturer","Manufacturer can't be Empty Text!");
                }
            }
        }
        public double Price
        {
            get { return this.price; }
            set
            {
                if (value >= 0)
                {
                    this.price = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("price","Price can't be negative!");
                }
            }
        }
        public string Owner
        {
            get { return this.owner; }
            set
            {
                if (value != String.Empty)
                {
                    this.owner = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("owner","Owner can't be Empty Text!");
                }
            }
        }
        public Battery GsmBattery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }
        public Display GsmDisplay
        {
            get { return this.display; }
            set { this.display = value; }
        }

        public static GSM IPhone4S
        {
            get { return iPhone4S; }
            //set { iPhone4S = value; }
        }

        public List<Call> CallHistory
        {
            get { return callHistory; }
            set { callHistory = value; }
        }

        //Constructors
        public GSM(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
        }
        public GSM(string model, string manufacturer, int price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.battery = battery;
            this.display = display;
        }

        // methods
        public void AddingCalls(Call call)
        {
            if (callHistory == null)
            {
                AddingCalls(0, call);
            }
            else
            {
                AddingCalls(callHistory.Count, call);
            }
        }
        
        public void AddingCalls(int index, Call call)
        {
            if (callHistory == null)
            {
                callHistory = new List<Call>();
            }
            if (index < callHistory.Count)
            {
                callHistory.Insert(index, call);
            }
            else
            {
                callHistory.Add(call);
            }
        }
        public void RemovingCalls(int index)
        {
            if (index < callHistory.Count)
            {
                this.callHistory.RemoveAt(index);
            }
        }
        public void ClearCalls()
        {
            this.callHistory.Clear();
        }
        public double CalcTotalPrice(double pricePerMinute)
        {
            double result = 0;
            foreach (var item in callHistory)
            {
                result += (item.Duration / 60)* pricePerMinute;
            }

            return Math.Round(result,2);
        }

        // override ToString Mettod
        public override string ToString()
        {
            string result = String.Format("Your GSM charackteristiks are:\nmodel : {0}\nmanufacturer : {1}", this.Model, this.Manufacturer);

            if (this.Price == 0)
            {
                result += "\nprise : [missing info]";
            }
            else
            {
                result += "\nprise : " + this.Price;
            }
            if (this.Owner == null)
            {
                result += "\nowner : [missing info]";
            }
            else
            {
                result += "\nowner : " + this.Owner;
            }
            if (this.battery.Model == null)
            {
                result += "\nBattery - model : [missing info]";
            }
            else
            {
                result += "\nBattery - model : " + this.battery.Model;
            }
            if (this.battery.HoursIdle == 0)
            {
                result += "; hoursIdle : [missing info]";
            }
            else
            {
                result += "; hoursIdle : " + this.battery.HoursIdle;
            }
            if (this.battery.HoursTalk == 0)
            {
                result += "; hoursTalk : [missing info]";
            }
            else
            {
                result += "; hoursTalk : " + this.battery.HoursTalk;
            }
            if (this.battery.Type == 0)
            {
                result += "; type : [missing info]";
            }
            else
            {
                result += "; type : " + this.battery.Type;
            }
            if (this.display.Size == 0)
            {
                result += "\nDisplay - size : [missing info]";
            }
            else
            {
                result += "\nDisplay - size : " + this.display.Size;
            }
            if (this.display.NumberofColors == 0)
            {
                result += "; numberofColors : [missing info]";
            }
            else
            {
                result += "; numberofColors : " + this.display.NumberofColors;
            }

            return result;
        }
    }
}
