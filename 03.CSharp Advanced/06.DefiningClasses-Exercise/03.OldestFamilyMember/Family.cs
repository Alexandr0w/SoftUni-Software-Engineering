using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldestFamilyMember
{
    public class Family
    {
        private readonly List<Person> members = new List<Person>();

        public void AddMember(Person member)
        {
            if (member is not null)
                this.members.Add(member);
        }
        public Person GetOldestMember() => this.members.OrderByDescending(p => p.Age).First();
    }
}
