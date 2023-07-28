using LinkedListLibrary;
using StackLibrary;

namespace ConsoleApp;

public class Program
{
    static void Main(string[] args)
    {
        #region LinkedListNode<int>
        //LinkedListNode<int> firstNode = new LinkedListNode<int>(1);
        //LinkedListNode<int> middleNode = new LinkedListNode<int>(5);
        //firstNode.NextNode = middleNode;

        //LinkedListNode<int> lastNode = new LinkedListNode<int>(10);
        //middleNode.NextNode = lastNode;

        //PrintList(firstNode);
        #endregion

        #region TestLinkedList<string>
        ////add nodes - first, last, middle
        //CustomLinkedList<string> strings = new CustomLinkedList<string>();
        //strings.AddFirst("first");
        //strings.AddLast("last");

        ////print head, tail,count, chain
        //Console.WriteLine(" - After adding first, last nodes to the chain");
        //Console.WriteLine($"\nFirst node value:     | {strings.Head}");
        //Console.WriteLine($"Last node value:      | {strings.Tail}");
        //Console.WriteLine($"Chain nodes' count:   | {strings.Count}");

        ////remove nodes
        //Console.WriteLine("\n- After removing first node");

        //if (strings.RemoveFirst())
        //    Console.WriteLine($"\nFirst node  value: {strings.Head}");
        //Console.WriteLine($"Chain nodes' count after removing first node:   | {strings.Count}");

        //Console.WriteLine("\n- After removing last node");
        //if (strings.RemoveLast())
        //    Console.WriteLine($"\nLast node value: {strings.Tail}");
        //Console.WriteLine($"Chain nodes' count after removing last:   | {strings.Count}");

        ////add some nodes and clear chain

        //strings.AddFirst("first");
        //strings.AddLast("last");
        //strings.PrintList();


        //Console.WriteLine("\n- After clearing the chain.");
        //strings.Clear();
        //strings.PrintList();
        #endregion

        #region Stack with linked List

        CustomStack<int> stackChain = new CustomStack<int>();
        stackChain.Push(1);
        stackChain.Push(20);
        stackChain.Push(100);
        stackChain.Push(4);
        stackChain.Push(7);
        stackChain.Push(10000);

        Console.WriteLine(stackChain.Peek()); //10000
        Console.WriteLine(stackChain.Pop());  //10000
        Console.WriteLine(stackChain.Peek()); //7

        #endregion
    }
}