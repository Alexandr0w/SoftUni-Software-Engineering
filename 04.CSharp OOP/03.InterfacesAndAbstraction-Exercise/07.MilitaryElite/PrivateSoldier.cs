using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class PrivateSoldier : BaseSoldier, IPrivateSoldier
    {
        public PrivateSoldier(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; }

        public override string ToString() => $"{base.ToString()} Salary: {this.Salary:F2}";
    }
}
