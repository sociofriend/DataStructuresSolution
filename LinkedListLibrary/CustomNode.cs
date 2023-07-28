using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListLibrary
{
    public class CustomNode<T>
    {
        public T Value { get; set; }
        public CustomNode<T> NextNode { get; set; }

        public CustomNode(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"Node Value: {Value}";
        }
    }
}
