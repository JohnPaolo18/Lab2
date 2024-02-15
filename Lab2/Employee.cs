using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Employee //base class
    {
        private string id;
        private string name;
        private string address;
        private string phone;
        private long sin;
        private string dob;
        private string dept;
        

        public Employee() { }

        public Employee(string Id, string name, string address, string phone, long sin, string dob, string dept)
        {
            this.Id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.sin = sin;
            this.dob = dob;
            this.dept = dept;
        }
        //getters and setters
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public long Sin
        {
            get { return sin; }
            set { sin = value; }
        }
        public string Dob
        {
            get { return dob; }
            set { dob = value; }
        }

        public virtual double GetPay() //will be implemented on derived classes
        {
            return 0;
        }
        //ToString method
        public override string ToString()
        {
            return $"ID: {id}, Name: {name}, Address: {address}, Phone: {phone}, sin: {sin}, DOB {dob}, Department {dept}";
        }

    }
}
