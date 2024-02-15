using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab2
{
    class Wages : Employee //derived class
    {
        private double rate;

        public double hours { get; set; }

        public Wages(string Id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(Id, name, address, phone, sin, dob, dept)
        {
            this.rate = rate;
            this.hours = hours;
        }

        public double hourlyrate
        {
            get { return rate; }
            set { rate = value; }
        }

        public override double GetPay()
        {
            if (hours < 40) 
            {
               return (hours * rate);
            }
            else
            {
                return (40 * rate) + ((hours - 40) * (rate * 1.5));
            }
        }
        public override string ToString()
        {
            return base.ToString() + $", Rate: {rate}, hours: {hours}";
        }
    }

}
