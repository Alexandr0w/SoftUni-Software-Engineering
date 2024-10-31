using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage
{
    public class Citizen : BaseBuyer, IBuyer
    {
        public Citizen(string name, int age, string id, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = birthDate;
        }

        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
        public string BirthDate { get; set; }

        protected override int FoodIncrement => 10;
    }
}
