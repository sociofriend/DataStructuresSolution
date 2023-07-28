using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LinkedListLibrary;
using StackLibrary;

namespace PostFixCalculator
{
    public class PostFixCalc
    {

        // stack linked list to push integers from the user input
        private CustomStack<int> NumbersStack { get; set; } = new CustomStack<int>();

        // to store the result of the calculation
        public int Result { get; set; }

        /// <summary>
        /// Constructor to make the calculator work
        /// </summary>
        public PostFixCalc()
        {
            Result = ModifyStack(GetUserInput());
        }

        /// <summary>
        /// Get and validate user input for Post Fix calculator expression.
        /// Breaks down the valid user input to string values using space (" ") as separation base.
        /// </summary>
        /// <returns>Returns array of strings.</returns>
        private string[] GetUserInput()
        {
            Console.Write($"\nYour expression for PostFix Calculator: ");
            Calculator calculator = new Calculator();
            calculator.Expression = Console.ReadLine();

            if (IsValid(calculator, calculator.Expression))
            {
                return calculator.ExpressionArray;
            }
            else
            {
                Console.WriteLine("Illegal input. Try again.");
                return GetUserInput();
            }
        }

        /// <summary>
        /// Calculates user expression by modifying the local stack: adds numbers ass operands till the operator happens.
        /// When the operator happens, does the calculation for the last two numbers, pops those numbers, then pushes the result, and so on.
        /// </summary>
        /// <param name="expressionArray">Array of strings to store number units from the user input.</param>
        /// <returns>Integery type value as the result of the overall calculation based on user input expression.</returns>
        private int ModifyStack(string[] expressionArray)
        {
            int result = 0;

            foreach (string element in expressionArray)
            {
                //store units into numbers' array if an integer
                if (int.TryParse(element, out int res))
                    NumbersStack.Push(res);

                //if an operator happens, do the math
                if (IsOperator(element))
                {
                    result = UseOperators(element, NumbersStack);
                    NumbersStack.Pop();
                    NumbersStack.Pop();
                    NumbersStack.Push((int)result);
                }
            }
            return result;
        }

        /// <summary>
        /// Does the math based on operator with two last elements of the stack.
        /// </summary>
        /// <param name="oper">Operator transferred as an argument.</param>
        /// <param name="stackNumbers">Stack of numbers.</param>
        /// <returns>Integer type value as a result of simple math operator of two last integers of the stack.</returns>
        public int UseOperators(string oper, CustomStack<int> stackNumbers)
        {

            int result = 0;
            int number1 = stackNumbers.Top.Value;
            int number2 = stackNumbers.Top.NextNode.Value;

            switch (oper)
            {
                case "+":
                    result = number1 + number2;

                    break;
                case "-":
                    result = number1 - number2;
                    break;
                case "*":
                    result = number1 * number2;
                    break;
                case "/":
                    result = number1 / number2;
                    break;
            }
            return result;
        }

        /// <summary>
        /// Validates user input.Thanks to ChatGPT :)
        /// </summary>
        /// <param name="calculator"> Calculator type object strong properties of expression and array of number inputs.</param>
        /// <param name="expression">String type value for storing the user input.</param>
        /// <returns></returns>
        private bool IsValid(Calculator calculator, string expression)
        {
            // Split the input expression into individual tokens based on spaces
            calculator.ExpressionArray = expression.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Variables to keep track of numbers and operators
            int operandCount = 0;
            int operatorCount = 0;

            foreach (string token in calculator.ExpressionArray)
            {
                if (int.TryParse(token, out _))
                {
                    // Token is a valid number (operand)
                    operandCount++;
                }
                else if (IsOperator(token))
                {
                    // Token is a valid operator
                    operatorCount++;
                }
                else
                {
                    // Token is not a valid number or operator
                    return false;
                }
            }

            // Check if the expression is valid (operatorCount = operandCount - 1)
            return operatorCount == operandCount - 1;
        }

        private bool IsOperator(string token)
        {
            // Define the valid operators here
            char[] validOperators = { '+', '-', '*', '/' };

            return token.Length == 1 && Array.IndexOf(validOperators, token[0]) >= 0;
        }
    }
}
