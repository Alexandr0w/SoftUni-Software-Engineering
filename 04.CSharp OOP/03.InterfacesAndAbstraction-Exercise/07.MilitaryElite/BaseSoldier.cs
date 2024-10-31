using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public abstract class BaseSoldier : ISoldier
    {
        protected BaseSoldier(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public override string ToString() => $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
    }
}
