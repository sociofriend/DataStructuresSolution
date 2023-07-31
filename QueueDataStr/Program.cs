using CustomQueueLibrary;
namespace QueueDataStr;

public class Program
{
    static void Main(string[] args)
    {
        CustomQueue<int> intsQueue = new CustomQueue<int>();

        intsQueue.Enqueue(1);
        intsQueue.Enqueue(2);
        intsQueue.Enqueue(3);
        intsQueue.Enqueue(4);
        intsQueue.Enqueue(5);

        Console.WriteLine(intsQueue.Peek()); // 1
        int currentServed = intsQueue.Head.Value;

        intsQueue.Dequeue(currentServed);
        Console.WriteLine(intsQueue.Peek()); // 2

    }
}