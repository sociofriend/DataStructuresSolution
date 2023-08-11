namespace BinaryTreeLibrary;

public delegate void OutputDelegate(string output);

// custome binary tree class shall implement IComparable<T> generic interface
// where the type shall also implement IComparable generic interface
public class CustomBinaryTree<T> where T : IComparable

{
    //list for storing all values of the tree
    public List<T> Values { get; set; }

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
        Values = new List<T>();
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
    /// Checks if the value is not present in the values' list, then adds it, and creates new tree.
    /// </summary>
    /// <param name="value">Generic type value to be added to the tree.</param>
    public void Add(T value)
    {
        //check if the value is not already in the values' tree
        if (!Values.Contains(value))
        {
           //if not, addd the value to the list, sort it
            Values.Add(value);
            Values.Sort();

            //crate new tree and reassign the root
            Root = AddValuesToTree(Values);
            
            //increment the count of the tree
            Count++;
        }
    }

    /// <summary>
    /// Creates new binary tree: gets middle value as root, and adds values bigger and less than middle value to the tree.
    /// </summary>
    /// <param name="values">List of generic type values representing all values of the tree.</param>
    /// <returns>Returns root node.</returns>
    private BinaryTreeNode<T> AddValuesToTree(List<T> values)
    {
        //find the middle value
        //in case of even numbers
        int count = values.Count;        
        int middleIndex = count / 2;
        
        //assign the root the middle value carry-ing new node
        Root = new BinaryTreeNode<T>(values[middleIndex]);
        
        //add values bigger than the middle value to the tree
        for (int i = middleIndex + 1; i < count; i++)
        {
            Root = AddRec(Root, values[i]);
        }

        //add values less than the middle value to the tree
        for (int i = middleIndex - 1; i >= 0; i--)
        {
            Root = AddRec(Root, values[i]);
        }

        //return the reassigned root
        return Root;
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
    /// Shows if the tree contains the given value.
    /// </summary>
    /// <param name="value">Generic type value.</param>
    /// <returns>Returns boolean type value.</returns>
    public bool Contains(T value)
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