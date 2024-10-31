using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MilitaryElite
{
    public class Commando : BaseSpecialisedSoldier, ICommando
    {
        private readonly List<IMission> _missions;
        public Commando(int id, string firstName, string lastName, decimal salary, string corps, IEnumerable<IMission> missions) : base(id, firstName, lastName, salary, corps)
        {
            this._missions = new List<IMission>(missions);
            this.Missions = this._missions.AsReadOnly();
        }

        public IReadOnlyCollection<IMission> Missions { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append("Missions:");

            foreach (IMission mission in this.Missions)
            {
                sb.AppendLine();
                sb.Append($"  {mission}");
            }

            return sb.ToString();
        }
    }
}
