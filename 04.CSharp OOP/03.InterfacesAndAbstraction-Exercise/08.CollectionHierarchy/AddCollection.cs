using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy
{
    public class AddCollection : ISupportsAdd
    {
        private readonly List<string> _list = new List<string>();
        public int Add(string item)
        {
            this._list.Add(item);
            return this._list.Count - 1;
        }
    }
}
