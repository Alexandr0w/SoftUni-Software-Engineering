using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class SmartPhone : IBrowser, ICaller
    {
        public string Browse(string url) => $"Browsing: {url}!";

        public string Call(string phoneNumber) => $"Calling... {phoneNumber}";
    }
}
