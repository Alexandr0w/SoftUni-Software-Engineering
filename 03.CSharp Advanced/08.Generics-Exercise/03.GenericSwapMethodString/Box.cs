using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GenericSwapMethodString
{
    public class Box<TValue>
    {
        public Box(TValue value)
        {
            this.Value = value;
        }

        public TValue Value { get; set; }

        public override string ToString() => $"{typeof(TValue)}: {(this.Value)}";
    }
}
