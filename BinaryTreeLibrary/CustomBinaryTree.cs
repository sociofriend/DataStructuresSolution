namespace BinaryTreeLibrary;

public delegate void OutputDelegate(string output);

// custome binary tree class shall implement IComparable<T> generic interface
// where the type shall also implement IComparable generic interface
public class CustomBinaryTree<T> where T : IComparable

{
    //number of nodes included in the tree
    public int Count { get; private set; } = 0;

    //the topmost node in a binary tree: all other nodes are descendants of the root.
    public BinaryTreeNode<T>? Root { get; set; }

    //local object of IPrintHelper type
    private readonly IPrintHelper _printHelper;
    
    //current node to be used in a certain operation
    public BinaryTreeNode<T> Current { get; set; }

    //default constructor to use delegate
    public CustomBinaryTree()
    {
        
    }

    /// <summary>
    /// Parameterized constructor to work with IPrintHelper interface
    /// </summary>
    /// <param name="printHelper">IPrintHelper type object</param>
    public CustomBinaryTree(IPrintHelper printHelper)
    {
        _printHelper = printHelper;
    }

    /// <summary>
    /// Compares to values to each other:
    /// - return negative integer if the current is less than the other,
    /// - returns positive value if the current is greater than the other,
    /// - returns 0, if two compared values are equal.
    /// </summary>
    /// <param name="other"></param>
    /// <returns>Returns an integer representing the result of comparison.</returns>
    public int CompareTo(T? other)
    {
        return Current.Value.CompareTo(other);
    }

    /// <summary>
    /// Calls local method to add a generic type object to tree,
    /// taking into account the root.
    /// </summary>
    /// <param name="value">Generic type value to be added to the tree.</param>
    public void Add(T value)
    {
        Root = AddRec(Root, value);
    }

    /// <summary>
    /// Adds the given value to the tree comparing with existing values 
    /// in each step starting from the root.
    /// </summary>
    /// <param name="root">Topmost node of the tree.</param>
    /// <param name="value">Given value to be added to the tree.</param>
    /// <returns>Returns BinaryTreeNode object accepting generic type objects.</returns>
    private BinaryTreeNode<T> AddRec(BinaryTreeNode<T> root, T value)
    {
        // if tree is empty, create new node and set it as the root
        if (root == null)
        {
            root = new BinaryTreeNode<T>(value);
            Count++;
        }

        //if tree is not empty
        else
        {
            //compare with root value
            if (value.CompareTo(root.Value) < 0)
                //if given value is less than the root value, than pass to left child,
                //invoke AddRec method on this child to start the comparison again.
                root.LeftNode = AddRec(root.LeftNode, value);

            else // (value.CompareTo(root.Value) >= 0)
                //in case the given value is greater or equal to the root value, pass to right child,
                //invoke AddRec method on this child to start the comparison again.
                root.RightNode = AddRec(root.RightNode, value);
        }
        
        //return root to pass it to class instance in project start.
        return root;
    }
    
    /// <summary>
    /// Invokes local method to add the given value to the tree, taking into account the root.
    /// </summary>
    /// <param name="value">Generic type inputted value.</param>
    public void Remove(T value)
    {
        //invoke the local value and reassign the root.
        Root = RemoveRec(Root, value);
    }

    /// <summary>
    /// Removes the given value from the tree by comparing with the existing values
    /// of the tree starting from the root.
    /// </summary>
    /// <param name="root">Topmost node of the tree.</param>
    /// <param name="value">Given value to be added to the tree.</param>
    /// <returns>Returns BinaryTreeNode object accepting generic type objects.</returns>
    private BinaryTreeNode<T> RemoveRec(BinaryTreeNode<T> root, T value)
    {
        //if the tree is returns null
        if (root == null)
            return root;

        //compare given value with the root value
        //if given value is less than root value, pass to left child.
        if (value.CompareTo(root.Value) < 0)    
            root.LeftNode = RemoveRec(root.LeftNode, value);

        //if given value is greate than root value, pass to right child
        else if (value.CompareTo(root.Value) > 0)
            root.RightNode = RemoveRec(root.RightNode, value);
        
        //if the given value matches the node.value look at the children.
        else
        {
            //if the parent node does not have left or right node, the process
            //will return its non-null child to its place.
            if (root.LeftNode == null)
                return root.RightNode;
            else if (root.RightNode == null)
                return root.LeftNode;
            //in case the parent has two children or does not have any
            //MinValue() method is invoked for right child to find the minimum value
            //among values greater than the parent node.value and returns it in the current
            //node's place.
            root.Value = MinValue(root.RightNode);
            
            //and then remove the duplicates of the parent node.
            root.RightNode = RemoveRec(root.RightNode, value);
        }

        Count--;
        //return reassigned root.
        return root;
    }

    /// <summary>
    /// Methods finds the minimum value starting from the given node.
    /// </summary>
    /// <param name="node">Given BinaryTreeNode<T>  type node.</param>
    /// <returns>Returns T generic type value.</returns>
    public T MinValue(BinaryTreeNode<T> node)
    {
        //create a temporary variable of generic type
        T minValue = node.Value;
        
        //while current node's leftNode is not null
        //(left nodes carry values less than the root)
        while (node.LeftNode != null)
        {
            //reassign temporary variable with less value.
            minValue = node.LeftNode.Value;
            
            //reassign the current node to its non-null nextNode.
            node = node.LeftNode;
        }
        
        return minValue;
    }


    /// <summary>
    /// Pre-order Traversal:
    /// Visit the root node, traverse the left subtree, and then traverse the right subtree.
    /// Used for creating a copy of the tree.
    /// </summary>
    /// <param name="parentNode">Parent node.</param>
    /// <param name="outputDelegate"> Delegate responsible for sending out string type value.</param>
    public void PreOrderTraversal(BinaryTreeNode<T> parentNode, OutputDelegate outputDelegate)
    {
        if (parentNode != null)
        {
            outputDelegate(parentNode.Value.ToString() + " ");
            PreOrderTraversal(parentNode.LeftNode, outputDelegate);
            PreOrderTraversal(parentNode.RightNode, outputDelegate);
        }
    }


    /// <summary>
    /// Method overload to work with IPrintHelper Inter
    /// </summary>
    /// <param name="parentNode"></param>
    public void PreOrderTraversal(BinaryTreeNode<T> parentNode)
    {
        if (parentNode != null)
        {
            _printHelper.Print(parentNode.Value.ToString() + " ");
            PreOrderTraversal(parentNode.LeftNode);
            PreOrderTraversal(parentNode.RightNode);
        }
    }

    /// <summary>
    /// In-Order Traversal: 
    /// Traverse the left subtree, visit the root node, and then traverse the right subtree.
    /// This is used for printing nodes in non-decreasing order for binary search trees.
    /// </summary>
    /// <param name="parentNode">Parent node.</param>
    /// <param name="outputDelegate"> Delegate responsible for sending out string type value.</param>
    public void InOrderTraversal(BinaryTreeNode<T> parentNode, OutputDelegate outputDelegate)
    {
        if (parentNode != null)
        {
            InOrderTraversal(parentNode.LeftNode, outputDelegate);
            outputDelegate(parentNode.Value.ToString() + " ");
            InOrderTraversal(parentNode.RightNode, outputDelegate);
        }
    }

    /// <summary>
    /// Post-Order Traversal: 
    /// Traverse the left subtree, traverse the right subtree,
    /// and then visit the root node. Used for deleting nodes from the tree.
    /// </summary>
    /// <param name="parentNode">Parent node.</param>
    /// <param name="outputDelegate"> Delegate responsible for sending out string type value.</param>
    public void PostOrderTraversal(BinaryTreeNode<T> parentNode, OutputDelegate outputDelegate)
    {
        if (parentNode != null)
        {
            PostOrderTraversal(parentNode.LeftNode, outputDelegate);
            PostOrderTraversal(parentNode.RightNode, outputDelegate);
            outputDelegate(parentNode.Value.ToString() + " ");
        }
    }

    /// <summary>
    /// Prints binary tree itself. Takes as argument root mode, depth of 
    /// the tree (starting from zero, as the operation starts from the root),
    /// as well as a boolean type custom argument showing if the node is the last one in the tree in certain path.
    /// </summary>
    /// <param name="root">BinaryTreeNode<T> type node topmost of the tree.</param>
    /// <param name="output">Delegate sending out string type values. Used to avoid Console.WriteLine in Library.</param>
    /// <param name="depth">Levels of the tree. Length of the longest path of the tree.</param>
    /// <param name="isLast">Boolean type variable identifying if the node is the last one in the tree.</param>
    public void PrintBinaryTree(BinaryTreeNode<T> root, Action<string> output, int depth = 0, bool isLast = true)
    {
        //stop the operation if the tree is empty.
        if (root == null)
            return;

        // create indentation based on depth
        string indent = new string(' ', depth * 4);

        // Create the formatted node string
        string nodeString = indent;
        if (isLast)
        {
            nodeString += "└── ";
            indent += "    ";
        }
        else
        {
            nodeString += "├── ";
            indent += "│   ";
        }
        nodeString += root.Value.ToString();

        // Invoke the provided output delegate
        output(nodeString);

        // Print left and right subtrees recursively
        PrintBinaryTree(root.LeftNode, output, depth + 1, false);
        PrintBinaryTree(root.RightNode, output, depth + 1, true);
    }

    /// <summary>
    /// Shows if the tree contains the given value.
    /// </summary>
    /// <param name="value">Generic type value.</param>
    /// <returns>Returns boolean type value.</returns>
    public bool Contains( T value)
    {
        return ContainsRec(Root, value);
    }

    /// <summary>
    /// Recursively compares the given value with the tree's existing values starting from the root.
    /// </summary>
    /// <param name="value">Generic type value.</param>
    /// <returns>Returns boolean type value.</returns>
    public bool ContainsRec(BinaryTreeNode<T> root, T value)
    {
        bool status = false;
        if (root != null)
        {
            if (value.CompareTo(root.Value) == 0)
                status = true;
            else if (value.CompareTo(root.Value) > 0)
            {
                return ContainsRec(root.RightNode, value);
            }
            else
            {
                return ContainsRec(root.LeftNode, value);
            }
        }
        return status;
    }
}