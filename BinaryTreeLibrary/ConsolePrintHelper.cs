using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLibrary
{
    public class ConsolePrintHelper : IPrintHelper
    {
        /// <summary>
        /// Print function for Console application type projects.
        /// </summary>
        /// <param name="input">String type value to print.</param>
        public void Print(string input)
        {
            Console.Write(input);
        }
    }
}
