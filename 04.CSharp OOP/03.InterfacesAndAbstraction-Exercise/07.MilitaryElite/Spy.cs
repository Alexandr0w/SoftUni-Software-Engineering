using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class Spy : BaseSoldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(); 
            sb.AppendLine(base.ToString());
            sb.Append($"Code Number: {this.CodeNumber}");

            return sb.ToString();
        }
    }
}
