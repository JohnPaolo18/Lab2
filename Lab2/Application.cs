using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Application
    {
        public List<Employee> Employees;

        public Application(string filepath)
        {
            Employees = new List<Employee>();
            LoadEmployees(filepath);
        }
        public void LoadEmployees(string filepath)
        {
            var lines = File.ReadAllLines(filepath);
            //loop that goes through each lines and parts of the text file
            foreach (var line in lines)
            {
                var employeeDetails = line.Split(':');
                string Id = employeeDetails[0];
                string Name = employeeDetails[1];
                string Address = employeeDetails[2];
                string phone = employeeDetails[3];
                long sin = long.Parse(employeeDetails[4]);
                string dob = employeeDetails[5];
                string dept = employeeDetails[6];

                //if-else statement to determine which is salary and rate/hours from the text file
                if (employeeDetails.Length == 8)
                {
                    double salary = double.Parse(employeeDetails[7]);
                    Employees.Add(new Salaried(Id, Name, Address, phone, sin, dob, dept, salary));
                }
                else if (employeeDetails.Length == 9)
                {
                    double rate = double.Parse(employeeDetails[7]);
                    double hours = double.Parse(employeeDetails[8]);

                    if (Id.StartsWith("5") || Id.StartsWith("6") || Id.StartsWith("7"))
                    {
                        Employees.Add(new Wages(Id, Name, Address, phone, sin, dob, dept, rate, hours));
                    }
                    else if (Id.StartsWith("8") || Id.StartsWith("9"))
                    {
                        Employees.Add(new PartTime(Id, Name, Address, phone, sin, dob, dept, rate, hours));
                    }
                }
            }
        }
        public double AverageWeeklyPay()
        {
            //Used the Employees.Average to calculate the average weekly pay, emp is short for employees
            //The ? operator is use to safely access the Getpay method
            //The ?? Null-coalensing operator is used in case a cast fail and return to null, a default value 0 will be used instead
            return Math.Round(Employees.Average(emp => (emp as Salaried)?.GetPay() ??(emp as Wages)?.GetPay() ?? (emp as PartTime)?.GetPay() ?? 0), 2);
        }
        //Method use to calculate the highest wage employee, use irder by descending and .First to show the first in the list
        public ( string, double) highestWageEmployee()
        {
            var highestwage = Employees.OfType<Wages>().OrderByDescending(w => w.GetPay()).First();
            return (highestwage.Name, highestwage.GetPay());
        }
        //Method use to calculate the lowest wage employee, use irder by descending and .First to show the first in the list
        public ( string, double) lowestWageEmployee()
        {
            var lowestwage = Employees.OfType<Wages>().OrderBy(w => w.GetPay()).First();
            return(lowestwage.Name, lowestwage.GetPay());
        }
        //Used Dictionary as categories to store Salaried, wages and partime employees and compute each percentage category
        public Dictionary<string, double> PercentageCategory()
        {
            int totalEmployees = Employees.Count();
            var categories = new Dictionary<string, double>
            {
                { "Salaried", Math.Round(Employees.OfType<Salaried>().Count() / (double)totalEmployees * 100, 2) },
                { "Wages", Math.Round(Employees.OfType<Wages>().Count() / (double)totalEmployees * 100, 2) },
                { "PartTime", Math.Round(Employees.OfType<PartTime>().Count() / (double)totalEmployees * 100, 2) }
            };
            return categories;
        }

    }
}
