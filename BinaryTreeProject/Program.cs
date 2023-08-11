using BinaryTreeLibrary;
using System.Xml.Linq;

namespace BinaryTreeProject;

internal class Program
{
    static void Main(string[] args)
    {
        // create an instance of binary tree class to hold string type values with default constructor
        CustomBinaryTree<string> tree = new CustomBinaryTree<string>();
        //CustomBinaryTree<int> tree = new CustomBinaryTree<int>();

        /// <summary>
        /// Creates an instance of the <see cref="IPrintHelper"/> interface and assigns it
        /// the implementation of <see cref="ConsolePrintHelper"/> for printing purposes.
        /// </summary>    
        IPrintHelper printHelper = new ConsolePrintHelper();

        // create an instance of binary tree class to hold string type values with parameterized constructor
        CustomBinaryTree<string> PrintableTree = new CustomBinaryTree<string>(printHelper: printHelper);

        //add values
        tree.Add("aa");
        tree.Add("ab");
        tree.Add("aas");
        tree.Add("ac");

        //tree.Add(1);
        //tree.Add(2);
        //tree.Add(3);
        //tree.Add(4);
        //tree.Add(5);

        // ** print binary tree in its original way

        //-- create a list type object to store the lines
        List<string> outputLines = new List<string>();


        //loop in the list object and print each line.
        foreach (var line in outputLines)
        {
            Console.WriteLine("\n" + line);
        }

        //print Traversal pre-order with Interface
        Console.Write("\n\nTraversal pre-order: ");

        // Perform a pre-order traversal on the printable binary tree with its root node,
        // potentially producing a formatted tree structure as output.
        PrintableTree.Root = tree.Root;
        PrintableTree.PreOrderTraversal(PrintableTree.Root);

        //print Traversal in-order
        Console.Write("\n\nTraversal in-order: ");
        tree.InOrderTraversal(tree.Root, HandleOutput);

        //print Traversal post-order
        Console.Write("\n\nTraversal post-order: ");
        tree.PostOrderTraversal(tree.Root, HandleOutput);

        //check if tree contains "ab";
        Console.WriteLine("\n\nTree contains \"ab\": " + tree.Contains("ab"));
        Console.WriteLine($"\n{tree.Count} nodes in the tree.");
    }

    /// <summary>
    /// Builds binary-tree value-by-balue.works with. Uses Add(T value) method of the 
    /// CustomBinaryTree class.
    /// </summary>
    /// <param name="charsTree">CustomeBInaryTree type object.</param>
    /// <param name="value">String type value input.</param>
    static void BuildBinaryTree(CustomBinaryTree<string> charsTree, string value)
    {
        //adds value to the tree in separate node
        charsTree.Add(value);
    }

    /// <summary>
    ///Works with OutputDelegate(string output) delegate. handles string values sent from 
    ///the BinaryTreeLibrary. Allows avoiding using console methods in library.
    /// </summary>
    /// <param name="output">String type output passed fromt he object.</param>
    static void HandleOutput(string output)
    {
        Console.Write(output);
    }
}