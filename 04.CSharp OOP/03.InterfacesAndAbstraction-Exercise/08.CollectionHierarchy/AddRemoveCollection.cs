using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : ISupportsAdd, ISupportsRemove
    {
        private readonly Queue<string> _queue = new();

        public int Add(string item)
        {
            this._queue.Enqueue(item);
            return 0;
        }

        public string Remove() => this._queue.Dequeue();
    }
}
