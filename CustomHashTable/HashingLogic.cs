using System;

namespace CustomHashTable;

public class HashingLogic
{
    //long type local variable to store the final convertion value
    public string FinalCode { get; set; }


    /// <summary>
    /// Parameterized constructor to assign the local variable for the final code
    /// </summary>
    /// <param name="text">String type variable representing input.</param>
    public HashingLogic(string text)
    {
        FinalCode = Encode(text);
    }

    /// <summary>
    /// In each 4-symbol element, the method converts each symbol to binary, then concatenates the result, 
    /// converts the binary string value to decimal, and concatenates to output string.
    /// </summary>
    /// <param name="text">String type variable representing input.</param>
    /// <returns>Returns string value representing encoded text.</returns>
    private string Encode(string input)
    {
        //start index of separating 4symbols from the main text
        int index = 0;
        
        //string to concatenate result from each 4symbols
        string stringResult = string.Empty;
        
        //substring for carrying each 4symbols
        string sbString = string.Empty;
        
        //trim every 4 symbols from the main text
        while(index < input.Length)
        {
            //make sure there are more 4 symbols left
            if ((input.Length - 1) - index > 4)
            {
                sbString = input.Substring(index, 4);
            }
            //otherwise just take what has remained
            else
            {
                sbString = input.Substring(index, input.Length - index);
            }
            
            //make conversion with 2 phases: 3symbols to binary-string value, binary-string into decimal-> string
            //return string value and concatenate with stringResult variable
            stringResult += BinaryToDecimal(FourSymbolsToBinary(sbString));

            //adjust indexing.
            index += 4;
        }

        return stringResult;
    }
    
    /// <summary>
    /// Converts binary string into decimal type value, and then converts it into string.
    /// </summary>
    /// <param name="binaryString">String type variable representing 4symbols' element binary value.</param>
    /// <returns>Returns string type value representing decimal digits.</returns>
    private string BinaryToDecimal(string binaryString)
    {
        //convert binary string into decimal with base 2
        decimal result = Convert.ToInt64(binaryString, 2);
        
        //convert to string and return
        return result.ToString();
    }

    /// <summary>
    /// Converts given string type value into concatenated result of separate symbols' binary strings.
    /// </summary>
    /// <param name="fourSymbols">In this context string is supposed to be comprised from mainly 4 symbols.</param>
    /// <returns>Returns string type value representing final concatenated value of the given string value.</returns>
    private string FourSymbolsToBinary(string fourSymbols)
    {
        fourSymbols = Reverse(fourSymbols);
        //string type local variable to represent concatenated result
        string stringResult = string.Empty;

        //loop through the string value's char elements
        foreach(char symbol in fourSymbols)
        {
            //in case is is an empty space, get the ready value
            if (symbol.Equals(' '))
                stringResult += "00100000";
            
            //otherwise invoke CharToBinary() method to convert each char to binary string
            else
                stringResult += CharToBinary(symbol);
        }

        return stringResult; 
    }

    /// <summary>
    /// Converts individual char type symbols into binary string.
    /// </summary>
    /// <param name="a">Char type given element.</param>
    /// <returns>Returns string type value representing the binary string of the given char element.</returns>
    private string CharToBinary(char a)
    {
        string stringResult = string.Empty;

        //get integer value of char symbol
        int b = a - 0;
        
        //while not 0, divide by 2
        while(b != 0)
        {
            //in case of even values add "0" to result
            if (b % 2 == 0)
                stringResult += "0";
            //otherwise add "1"
            else
                stringResult += "1";

            //divide by 2 to get a new integer
            b /= 2;
        }
        
        //reverse result
        stringResult = Reverse(stringResult);
        
        //check if the length is less than 8, add "0"-s from the left
        if(stringResult.Length < 8)
        {
            //0-s will be added from the left to achieve length = 0
            stringResult = stringResult.PadLeft(8, '0');
        }

        return stringResult;
    }

    /// <summary>
    /// Reverses the order of char elements of the string value.
    /// </summary>
    /// <param name="word">String type given value.</param>
    /// <returns><Returns string type value representing reversed version of the input./returns>
    private string Reverse(string word)
    {
        //create and array to store input's elements
        char[] chars = new char[word.Length];
        
        //add chars of the string starting from the beginning to the end of array
        int index = word.Length-1;
        foreach(char c in word )
        {
            chars[index] = c; 
            index--;
        }

        return string.Join("", chars);
    }
    
}
