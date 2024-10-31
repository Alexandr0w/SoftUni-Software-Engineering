using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterfaces
{
    public interface IPerson
    {
        int Age { get; }
        string GetName();
    }
}
