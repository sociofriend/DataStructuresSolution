namespace QueueWithArrayLibrary;

public class CustomQueueWithArray<T> : IEnumerable<T>
{
    //create initial array for storing the values with Length==1
    public T[] QueueArray { get; set; } = new T[1];

    //Index of the next item
    public int Index = 0;
    
    //local variable representing currently served value
    public T Head;
    
    //length of the array
    public int Length;

    //clear the array by assigning a reference to an empty array.
    public void Clear()
    {
        QueueArray = new T[1];
    }

    //add elements in the end of the queue (Last in last out)
    public void Enqueue(T value)
    {
        //if stack is yet empty, add the element at the beginning of the array
        if (Index == 0)
        {
            QueueArray[0] = value;
        }
        //if stack is not empty
        else
        {
            //create new array (Length+1) 
            T[] newStackArray = new T[Index + 1];

            ///copy elements
            for (int i = 0; i < QueueArray.Length; i++)
            {
                newStackArray[i] = QueueArray[i];
            }

            //change the reference of the main array
            QueueArray = newStackArray;

            //add the new item at the end of the new array.
            QueueArray[QueueArray.Length - 1] = value;
        }

        //change local properties describing the queue
        Index++;
        Head = QueueArray[0];
        Length = QueueArray.Length;
    }

    //remove current served item from the beginning of the queue.
    public T Dequeue()
    {
        //if the queue is not empty
        if (Length != 0)
        {
            //store the currently served value in the local variable
            T currentNumber = QueueArray[0];

            //create a new temporary array(Length-1)
            T[] trimmedArray = new T[QueueArray.Length - 1];

            //copy all elements of the main array here starting from the index=1 (to avoid first element)
            for (int i = 0; i < trimmedArray.Length; i++)
            {
                trimmedArray[i] = QueueArray[i + 1];
            }
            
            //change the reference of the main array
            QueueArray = trimmedArray;

            //change local properties describing the queue
            Index--;
            Length = QueueArray.Length;
            return currentNumber;
        }
        //if the queue is empty, throw an exception to handle it furtherly
        else
            throw new Exception("QueueWithArray is empty");
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Index; i++)
        {
            yield return QueueArray[i];
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<T>)this).GetEnumerator();
    }
}