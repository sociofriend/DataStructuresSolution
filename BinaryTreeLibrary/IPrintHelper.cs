using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLibrary;

public interface IPrintHelper
{
    /// <summary>
    /// Represents a method for printing a string, allowing types implementing
    /// this interface to define their own way of printing the input.
    /// </summary>
    /// <param name="input">The string to be printed.</param>
    public void Print(string input);
}
