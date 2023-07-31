using StackLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostFixCalculator;

public class PostfixToInfixConverter
{
    /// <summary>
    /// Converts PostFix expression to InFix expression and returns it as string value.
    /// </summary>
    /// <param name="postfixExpression">Validated user input of string type.</param>
    /// <returns>Returns string type value representing converted expression.</returns>
    public static string ConvertToInfix(string postfixExpression)
    {
        
        //create local variable for stack of string type elements, corresponding to expression parts.
        CustomStack<string> stack = new CustomStack<string>();
        
        //split user expression to string tokens
        string[] tokens = postfixExpression.Split(' ');

        //run loop through the stack and if is operand, just pushes it, and if is operator, concat 1st and 2nd operands
        foreach (string token in tokens)
        {
            //check if is operand
            if (IsOperand(token))
            {
                //push to stack of expression-tokens
                stack.Push(token);
            }
            //check if is operator
            else if (IsOperator(token))
            {
                //pop and store last added value
                string operand2 = stack.Pop();
                
                //pop and store first added value (stack becomes empty)
                string operand1 = stack.Pop();
                
                //create a subexpression and assign it the concatenated value of 1st operand, operator and second operand
                string subexpression = $"({operand1} {token} {operand2})";
                
                //push the string value to stack as first operand for further concatenation
                stack.Push(subexpression);
            }
        }
        //return last added and the only element of the stack
        return stack.Pop();
    }

    /// <summary>
    /// Validates if the token is an operand.
    /// </summary>
    /// <param name="token">String type value extracted from the user input for postfix expression.</param>
    /// <returns>Returns boolean type value representing the status of validation. True, if the token is operand.</returns>
    private static bool IsOperand(string token)
    {
        return int.TryParse(token, out _);
    }

    /// <summary>
    /// Validates if the token is an operator.
    /// </summary>
    /// <param name="token">String type value extracted from the user input for postfix expression.</param>
    /// <returns>Returns boolean type value representing the status of validation. True, if the token is operator.</returns>
    private static bool IsOperator(string token)
    {
        return token == "+" || token == "-" || token == "*" || token == "/";
    }
}

