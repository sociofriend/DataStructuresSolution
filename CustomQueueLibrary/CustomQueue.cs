using System.Collections;
using LinkedListLibrary;

namespace CustomQueueLibrary;

public class CustomQueue<T> : IEnumerable<T>
{
    
    CustomLinkedList<T> queueLinkedList = new CustomLinkedList<T>();

    public CustomNode<T> Head { get; set; } 
    public int Count { get; set; }

    public void Enqueue(T value)
    {
        if(queueLinkedList.Count == 0)
            queueLinkedList.AddFirst(value);
        else
            queueLinkedList.AddLast(value);

        Head = queueLinkedList.Head;
    }

    public T Dequeue(T value)
    {
        T currentServedValue = queueLinkedList.Head.Value;
        queueLinkedList.RemoveFirst();

        return currentServedValue;
    }
    
    public T Peek()
    {
        return queueLinkedList.Head.Value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        CustomNode<T> current = Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<T>)this).GetEnumerator();
    }
}