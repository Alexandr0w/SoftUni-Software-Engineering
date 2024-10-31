using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public abstract class BaseSpecialisedSoldier : PrivateSoldier, ISpecialisedSoldier
    {
        protected BaseSpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append($"Corps: {this.Corps}");

            return sb.ToString();
        }
    }
}
