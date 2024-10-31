using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy
{
    public class MyList : ISupportsAdd, ISupportsRemove, ICountable
    {
        private readonly Stack<string> _stack = new();

        public int Count => this._stack.Count;

        public int Add(string item)
        {
            this._stack.Push(item);
            return 0;
        }

        public string Remove() => this._stack.Pop();
    }
}
