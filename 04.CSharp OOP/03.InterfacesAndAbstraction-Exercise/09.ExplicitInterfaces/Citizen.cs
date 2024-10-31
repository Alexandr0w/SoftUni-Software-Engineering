using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterfaces
{
    public class Citizen : IPerson, IResident
    {
        private readonly string _name;

        public Citizen(string name, int age, string country)
        {
            this._name = name;
            this.Age = age;
            this.Country = country;
        }

        public int Age { get; }
        public string Country { get; }

        public string GetName() => this._name;

        string IResident.GetName() => $"Mr/Ms/Mrs {this.GetName()}";
    }
}
