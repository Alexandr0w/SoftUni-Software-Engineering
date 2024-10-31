using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class Engineer : BaseSpecialisedSoldier, IEngineer
    {
        private readonly List<IRepair> _repairs;

        public Engineer(int id, string firstName, string lastName, decimal salary, string corps, IEnumerable<IRepair> repairs) : base(id, firstName, lastName, salary, corps)
        {
            this._repairs = new List<IRepair>(repairs);
            this.Repairs = this._repairs.AsReadOnly();  
        }

        public IReadOnlyCollection<IRepair> Repairs { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(); 
            sb.AppendLine(base.ToString());
            sb.Append("Repairs:");

            foreach (IRepair repair in this.Repairs)
            {
                sb.AppendLine();
                sb.Append($"  {repair}");
            }

            return sb.ToString();
        }
    }
}
