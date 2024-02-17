using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            //filepath of employee.text file
            string filePath = "../../employees.txt";

            Application application = new Application(filePath);

            var averagePay = application.AverageWeeklyPay();
            var highestWagePay = application.highestWageEmployee();
            var lowestSalariedPay = application.lowestWageEmployee();
            var percentageOfEmployeeCategories = application.PercentageCategory();


            Console.WriteLine($"Average Weekly Pay: ${averagePay}");
            Console.WriteLine($"Highest Wage Pay: Name: {highestWagePay.Item1} Salary: ${highestWagePay.Item2}");
            Console.WriteLine($"Lowest Salaried Pay: Name: {lowestSalariedPay.Item1} Salary: ${lowestSalariedPay.Item2}");
            Console.WriteLine("Percentage of Employee Categories:");
            foreach (var category in percentageOfEmployeeCategories)
            {
                Console.WriteLine($"{category.Key}: {category.Value}%");
            }
        }
    }
}