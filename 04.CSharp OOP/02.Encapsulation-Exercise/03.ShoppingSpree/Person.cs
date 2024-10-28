using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Person
    {
        private readonly List<Product> _bag = new List<Product>();

        public Person(string name, decimal money)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty.");
            if (money < 0) throw new ArgumentException("Money cannot be negative.");

            this.Name = name;
            this.Money = money;
            this._bag = new List<Product>();
            this.Bag = this._bag.AsReadOnly();
        }
        public string Name { get; } 
        public decimal Money { get; }
        public IReadOnlyCollection<Product> Bag { get; }
    }
}
