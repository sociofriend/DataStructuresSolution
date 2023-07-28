using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListLibrary
{
    public class Print<T>
    {
        public static void PrintList(CustomNode<T> node)
        {
            //1st solution
            Console.Write(node.Value + " ");
            if (node.NextNode != null)
            {
                PrintList(node.NextNode);
            }

            ////2nd solution
            //while (node.NextNode != null)
            //{
            //    Console.Write(node.Value+ " ");
            //    node = node.NextNode;
            //}
        }



        public static void PrintNode(CustomNode<T> node)
        {
            Console.Write("Requested node: ");
            if (node != null)
            {
                node.ToString();
            }
            else
            {
                Console.WriteLine("Node does not exist.");
            };
        }


    }
}
