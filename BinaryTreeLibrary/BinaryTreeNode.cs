
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

    //the right child node contains a value greater than the parent node's value
    public BinaryTreeNode<T> RightNode { get; set; }

    //left child node contains a value less than or equal to the parent node's value
    public BinaryTreeNode<T> LeftNode { get; set; }

    public BinaryTreeNode(T value)
    {
        Value = value;
    }
}
