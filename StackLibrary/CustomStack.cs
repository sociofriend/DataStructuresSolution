using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedListLibrary;

namespace StackLibrary;

public class CustomStack<T>
{
    CustomLinkedList<T> list = new CustomLinkedList<T>();
    public CustomNode<T> Top { get; set; }

    public void Push(T v)
    {
        list.AddFirst(v);
        Top = list.Head;
    }

    public T Peek()
    {
        return list.Head.Value;
    }

    public T Pop()
    {
        CustomNode<T> tempNode = list.Head;
        list.RemoveFirst();
        Top = list.Head;
        return tempNode.Value;
    }
}
