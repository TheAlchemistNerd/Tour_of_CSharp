using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDB
{
    class Employee
    {
        // instance variables
        string _firstName;
        string  _lastName;
        decimal _monthlySalary;

        // Constructor
        public Employee(string firstName, string lastName, decimal monthlySalary)
        {
            _firstName = firstName;
            _lastName = lastName;
            _monthlySalary = monthlySalary;
        }

        // properties
        public string FirstName 
        { 
            get => _firstName; 
            set => _firstName = value; 
        }
        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }
        public decimal MonthlySalary
        {
            get => _monthlySalary;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} must not be negative");
                _monthlySalary = value;
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} yearly salary is {MonthlySalary * 12}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * System.IO.StreamWriter sw = new System.IO.StreamWriter("debug.txt");
             * sw.AutoFlush = true;
             * Console.SetOut(sw);
             */
            Employee emp_1 = new Employee("Allison", "Becker", 200000);
            Employee emp_2 = new Employee("David", "DeGea", 220000);
            Employee emp_3 = new Employee("Edward", "Mendy", 185000);

            Console.WriteLine(emp_1);
            Console.WriteLine(emp_2);
            Console.WriteLine(emp_3);

            emp_1.MonthlySalary = calculateSalaryRaise(10, emp_1);
            emp_2.MonthlySalary = calculateSalaryRaise(10, emp_2);
            emp_3.MonthlySalary = calculateSalaryRaise(10, emp_3);

            Console.WriteLine("\nNew Employee Salary");

            Console.WriteLine(emp_1);
            Console.WriteLine(emp_2);
            Console.WriteLine(emp_3);

            Console.ReadKey();


        }

        public static decimal calculateSalaryRaise(decimal raise, Employee emp)
        {
            decimal newMonthlySalary = (1 + raise / 100) * emp.MonthlySalary;
            return newMonthlySalary;
        }
    }

}
