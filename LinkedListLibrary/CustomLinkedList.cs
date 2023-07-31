using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListLibrary;
    public class CustomLinkedList<T> : ICollection<T>
    {
        //local property representing Head(1st value) of the stack
        public CustomNode<T> Head { get; private set; }
        
        //local property representing Tail(last value) of the stack
        public CustomNode<T> Tail { get; private set; }

        #region ICollection
        public int Count { get; private set; }
        public bool IsReadOnly { get => false; }
        public void Add(T item)
        {
            AddLast(item);
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            CustomNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                    return true;
                current = current.NextNode;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            CustomNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.NextNode;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            CustomNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
        #endregion

        #region Add
        /// <summary>
        /// Calls method overload to add the node at the beginning of the chain.
        /// </summary>
        /// <param name="item">T type item.</param>
        /// <returns>Returns first node created when the method is invoked.</returns>
        public void AddFirst(T item)
        {
            #region 1st solution
            //linkedlistnode<t> firstnode = new linkedlistnode<t>(item);
            //if (count != 0)
            //{
            //    firstnode.nextnode = head;
            //}

            //head = firstnode;
            //count++;

            //if (count == 1)
            //    Tail = Head;
            #endregion

            //2nd solution
            AddFirst(new CustomNode<T>(item));

        }

        /// <summary>
        /// Creates first node of the chain.
        /// </summary>
        /// <param name="node">LinkedListNode<T> type object with Value and neighbor node's properties.</param>
        /// <returns>Returns the node with the item and </returns>
        private void AddFirst(CustomNode<T> node)
        {
            if (Head != null)
            {
                node.NextNode = Head;
                Head = node;
            }
            else
            {
                Head = node;
                Tail = node;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            if (Count == 0)
            {
                AddFirst(item);
            }
            else
            {
                AddLast(new CustomNode<T>(item));
            }
        }

        private void AddLast(CustomNode<T> lastNode)
        {
            Tail.NextNode = lastNode;
            Tail = lastNode;

            Count++;
        }

        public void AddMiddle(T item, CustomNode<T> previousNode)
        {
            if (previousNode != null)
            {
                if (previousNode.NextNode != null)
                    AddMiddle(new CustomNode<T>(item), previousNode);
                else
                    AddLast(item);
            }
            else
            {
                AddFirst(item);
            }
        }

        private void AddMiddle(CustomNode<T> middleNode, CustomNode<T> previousNode)
        {
            middleNode.NextNode = previousNode.NextNode;
            previousNode.NextNode = middleNode;

            Count++;
        }
        #endregion

        #region Remove
        public bool RemoveFirst()
        {
            if (Head == null)
            {
                Console.WriteLine("Empty chain.");
                return false;
            }
            else
            {
                if (Count != 1)
                {
                    Head = Head.NextNode;
                    Count--;
                    return true;
                }
                else
                {
                    Clear();
                    return true;
                }
            }

        }

        public bool RemoveLast()
        {
            if (Count == 0)
            {
                Console.WriteLine("Empty chain!!");
                return false;
            }
            else
            {
                if (Count > 1)
                {
                    CustomNode<T> tempNode1 = Head.NextNode;
                    CustomNode<T> tempNode2 = tempNode1.NextNode;
                    while (tempNode1.NextNode != null)
                    {
                        tempNode1 = tempNode2;
                        tempNode2 = tempNode2.NextNode;
                    }
                    tempNode1.NextNode = null;
                    Tail = tempNode1;
                    Count--;
                }
                else
                {
                    Clear();
                }
                return true;
            }
        }

        public bool Remove(T value)
        {
            return Remove(new CustomNode<T>(value));
        }

        public bool Remove(CustomNode<T> node)
        {
            CustomNode<T> tNode = Head;
            while (tNode.NextNode != node)
            {
                tNode = tNode.NextNode;
            }
            tNode.NextNode = node.NextNode;
            return true;
        }
        #endregion

        #region
        public void PrintList()
        {
            if (Count == 0)
            {
                Console.WriteLine("Empty chain.");
            }
            else
            {
                CustomNode<T> nodeToPrint = Head;
                while (nodeToPrint != null)
                {
                    Console.WriteLine(nodeToPrint);
                    nodeToPrint = nodeToPrint.NextNode;
                }
            }

        }
        #endregion
    }

