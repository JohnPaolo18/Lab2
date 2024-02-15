using System;


namespace Lab2
{
    class Salaried : Employee
    {
        private double salary;

        public Salaried(string Id, string name, string address, string phone, long sin, string dob, string dept, double salary): base (Id, name, address, phone, sin, dob, dept)
        {
            this.salary = salary;
        }

        public double Salary 
        { 
            get {  return salary; } 
            set {  salary = value; } 
        }

        public override double GetPay()
        {
            return Salary;
        }
        public override string ToString()
        {
            return base.ToString() + $" Salary: { Salary}";
        }




    }
}
