using BinaryTreeLibrary;
namespace BinaryTreeProject;

internal class Program
{
    static void Main(string[] args)
    {
        // create an instance of binary tree class to hold string type values
        CustomBinaryTree<string> tree = new CustomBinaryTree<string>();
        
        //add values
        BuildBinaryTree(tree, "aa");
        BuildBinaryTree(tree, "ab");
        BuildBinaryTree(tree, "aas");
        BuildBinaryTree(tree, "ac");

        //print binary tree in its original way
        
        //-- create a list type object to store the lines
        List<string> outputLines = new List<string>();
        
        //starting from the root, add each node as new line.lambda expression
        tree.PrintBinaryTree(tree.Root, line => outputLines.Add(line));

        //loop in the list object and print each line.
        foreach (var line in outputLines)
        {
            Console.WriteLine("\n"+line);
        }

        //print Traversal pre-order
        Console.Write("\n\nTraversal pre-order: ");
        tree.PreOrderTraversal(tree.Root, HandleOutput);

        //print Traversal in-order
        Console.Write("\n\nTraversal in-order: ");
        tree.InOrderTraversal(tree.Root, HandleOutput);

        //print Traversal post-order
        Console.Write("\n\nTraversal post-order: ");
        tree.PostOrderTraversal(tree.Root, HandleOutput);

        //check if tree contains "ab";
        Console.WriteLine("\n" + tree.Contains("ab"));
    }

    /// <summary>
    /// Builds binary-tree value-by-balue.works with. Uses Add(T value) method of the 
    /// CustomBinaryTree class.
    /// </summary>
    /// <param name="charsTree">CustomeBInaryTree type object.</param>
    /// <param name="value">String type value input.</param>
    static void BuildBinaryTree(CustomBinaryTree<string> charsTree, string value)
    {
        //adds value to the tree in sepatare node
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