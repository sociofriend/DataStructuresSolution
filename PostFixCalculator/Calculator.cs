using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostFixCalculator
{
    public class Calculator
    {
        // store user input 
        public string Expression { get; set; }

        // transfer user input to array of strings
        public string[] ExpressionArray { get; set; }
    }
}
