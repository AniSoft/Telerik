using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.HumanClasses
{
    public class Worker: Human
    {
        private double weekSalary;
        private double workHoursPerDay;

        public double WeekSalary
        {
            get
            {
                return weekSalary;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Week salary must be a positive number.");
                }
                weekSalary = value;
            }
        }
        public double WorkHoursPerDay
        {
            get
            {
                return workHoursPerDay;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Work hours per day must be a positive number.");
                }
                workHoursPerDay = value;
            }
        }

        // Constructor
        public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public double MoneyPerHour()
        {
            return Math.Round(WeekSalary / 5 / WorkHoursPerDay,2);
        }

        public override string ToString()
        {
            return String.Format("{0} {1}: week selary:{2}; work hours per day:{3}; money per hour:{4}.", FirstName, LastName, WeekSalary,WorkHoursPerDay,MoneyPerHour());
        }
    }
}
