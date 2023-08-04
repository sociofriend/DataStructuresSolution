
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLibrary;

public class BinaryTreeNode<T> where T : IComparable
{
    //value that node contains
    public T Value { get; set; }

    //top node of a binary tree
    public bool StatusRoot { get; set; }

    //node with no children
    public bool StatusLeaf { get; set; }

    //the length of the path from the root to the node
    public int Depth { get; set; }

    //parent node
    BinaryTreeNode<T> ParentNode { get; set; }
    BinaryTreeNode<T> SiblingNode { get; set; }



    //the right child node contains a value greater than the parent node's value
    public BinaryTreeNode<T> RightNode { get; set; }

    //left child node contains a value less than or equal to the parent node's value
    public BinaryTreeNode<T> LeftNode { get; set; }

    public BinaryTreeNode(T value)
    {
        Value = value;
    }


    public int CompareTo(T? other)
    {
        return Value.CompareTo(other);
    }
}
