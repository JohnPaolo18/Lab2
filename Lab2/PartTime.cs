using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class PartTime: Employee //derived class
    {
        private double rate;

        public double hours { get; set; }

        public PartTime(string Id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(Id, name, address, phone, sin, dob, dept)
        {
            this.Rate = rate;
            this.hours = hours;
        }

        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public override double GetPay()
        {
            return Rate * hours;
        }
        public override string ToString()
        {
            return base.ToString() + $", Rate: {rate}, hours: {hours}";
        }
    }
}
