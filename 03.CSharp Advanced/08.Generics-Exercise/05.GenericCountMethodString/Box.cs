using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCountMethodString
{
    public class Box<TValue> : IComparable<Box<TValue>>
        where TValue : IComparable<TValue>
    {
        public TValue Value { get; set; }

        public int CompareTo(Box<TValue> other)
        {
            return this.Value.CompareTo(other.Value);
        }

        public override string ToString() => $"{typeof(TValue)}: {Value}";
    }
}
