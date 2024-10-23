using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Animal
    {
        public Animal(string name, int age, string gender)
        {
            if (age <= 0) throw new ArgumentException("Invalid input!");    

            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name { get; }
        public int Age { get; }
        public string Gender { get; }

        public virtual string ProduceSound() => string.Empty;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.Append(this.ProduceSound());

            return sb.ToString();
        }
    }
}
