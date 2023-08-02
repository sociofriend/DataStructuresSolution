using System.Collections;
using LinkedListLibrary;

namespace CustomQueueLibrary;

public class CustomQueue<T> : IEnumerable<T>
{
    //create a custom LinkedLust object for Queue
    CustomLinkedList<T> queueLinkedList = new CustomLinkedList<T>();

    //create a CustomNode local variable for storing the current served value
    public CustomNode<T> Head { get; set; }
    
    //count of the nodes in the queue linked list
    public int Count;

    /// <summary>
    /// Clears the queue.
    /// </summary>
    public void Clear()
    {
        queueLinkedList.Clear();
        Head = null;
        Count = 0;
    }

    /// <summary>
    /// add a value to Queue
    /// </summary>
    /// <param name="value">Argument to be stored as value.</param>
    public void Enqueue(T value)
    {
        //check if the LinkedList is empty
        if(queueLinkedList.Count == 0)
            queueLinkedList.AddFirst(value);
        else
            queueLinkedList.AddLast(value);

        //initialize the local variable for current served value.
        Head = queueLinkedList.Head;
        Count = queueLinkedList.Count;
    }

    /// <summary>
    /// Delets/Pops first input (first in first out(FIFO)).
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Returns the value which was removed from the queue.</returns>
    public T Dequeue(T value)
    {
        T currentServedValue = queueLinkedList.Head.Value;
        queueLinkedList.RemoveFirst();
        Head = queueLinkedList.Head;
        Count = queueLinkedList.Count;
        return currentServedValue;
    }

    /// <summary>
    /// Deletes/Pops first input (first in first out(FIFO)).
    /// </summary>
    /// <returns>Returns the value which was removed from the queue.</returns>
    public T Dequeue()
    {
        //check if queue is not empty
        if (Count != 0)
        {
            // if not empty do the dequeue operation
            
            //store current served value in local variable of T type
            T currentServedValue = queueLinkedList.Head.Value;
            
            //remove current served value from the queue
            queueLinkedList.RemoveFirst();
            
            // check if queue is not empty after removal and reassign the Head
            if (queueLinkedList.Count != 0)
            {
                Head = queueLinkedList.Head;
            }
            else
            {
                Head = null;
            }
            
            //decrement the count of the itemsin teh queue
            Count--;
            
            //return the initially stored value served
            return currentServedValue;
        }
        //if queue is empty at the moment of Dequeu event is handled throw an exception
        else
        {
            throw new Exception("Queue is empty.");
        }
    }

    /// <summary>
    /// Shows current item in the queue to be served.
    /// </summary>
    /// <returns>Returns value stored in the curent node.</returns>
    /// <exception cref="InvalidOperationException">Throws exception in case of empty queque.</exception>
    public T Peek()
    {
        if (Head != null)
            return queueLinkedList.Head.Value;
        else
            throw new Exception("Empty queue list.");
    }
    /// <summary>
    /// Ensures the que is enumerable.
    /// </summary>
    /// <returns>Returns GetEnumerator() method of custom LinkedList.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        return queueLinkedList.GetEnumerator();
    }

    /// <summary>
    /// Non-generic getEnumberator(0 method.
    /// </summary>
    /// <returns></returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<T>)this).GetEnumerator();
    }
}