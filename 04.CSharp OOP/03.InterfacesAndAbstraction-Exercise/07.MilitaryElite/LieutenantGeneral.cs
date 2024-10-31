using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class LieutenantGeneral : PrivateSoldier, ILieutenantGeneral
    {
        private readonly List<ISoldier> _privates;

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            this._privates = new List<ISoldier>();
            this.Privates = this._privates.AsReadOnly();
        }

        public IReadOnlyCollection<ISoldier> Privates { get; }

        public bool AddPrivate(ISoldier @private)
        {
            if (@private is null) return false;

            this._privates.Add(@private);
            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append("Privates:");

            foreach (var @private in this.Privates)
            {
                sb.AppendLine();
                sb.Append("  ");
                sb.Append(@private);
            }

            return sb.ToString();
        }
    }
}
