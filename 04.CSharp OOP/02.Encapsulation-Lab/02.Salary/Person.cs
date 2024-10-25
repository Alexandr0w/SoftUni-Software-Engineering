using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Person
    {
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public decimal Salary { get; private set; }

        public override string ToString() => $"{FirstName} {LastName} receives {Salary:F2} leva.";

        public void IncreaseSalary(decimal percentage)
        {
            decimal salaryIncrease = Salary * percentage / 100;
            if (Age < 30)
            {
                salaryIncrease /= 2;
            }

            Salary += salaryIncrease;
        }
    }
}
