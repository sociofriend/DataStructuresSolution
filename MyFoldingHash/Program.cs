namespace MyFoldingHash;

public class Program
{
    static void Main(string[] args)
    {
        //check if it works for the example
        GetNextBytes(0, "lore");

        //local variable for storing the input
        string input = string.Empty;

        //if "quit" is input, stop the operation
        while(!input.Equals("quit", StringComparison.OrdinalIgnoreCase))
        {
            //put some beginning
            Console.Write("> ");
            
            //get user input for conversion
            input = Console.ReadLine();

            //get back the result.
            Console.WriteLine("Folding: {0}", FoldingHash(input));
        }
    }

    /// <summary>
    /// Is calculated for 4 symbol-inputs. For first symbol gets its byte representation, 
    /// starting from the second symbol, it adds 0-s of given numbers from right to left to
    /// he binary representation of the respective symbol (in case of 2nd operation it will be "o").
    /// </summary>
    /// <param name="startIndex">Integer type variable representing the index of the symbol in  the input.</param>
    /// <param name="str">String type value representing user inputs' current 4 symbols.</param>
    /// <returns>Returns the integer type value representing the result of the calculation.</returns>
    private static int GetNextBytes(int startIndex, string str)
    {
        int currentFourBytes = 0;

        currentFourBytes += GetBytes(str, startIndex);              //returned 108     
        currentFourBytes += GetBytes(str, startIndex + 1) << 8;     // adds 8 0-s to  ((int)o = 111's binary value(01101111)),
                                                                    // so it is multiplyed by 2^8=256  => 108 + 28416 = 28524
        currentFourBytes += GetBytes(str, startIndex + 2) << 16;
        currentFourBytes += GetBytes(str, startIndex + 3) << 24;

        return currentFourBytes; // 7499628
    }

    /// <summary>
    /// Calculates the byte representation of the given symbol of the given input.
    /// </summary>
    /// <param name="str">String type value representing user inputs' current 4 symbols.</param>
    /// <param name="index">Integer type variable representing the index of the symbol in  the input</param>
    /// <returns>Returns integer type value representing byte value of the given symbol.</returns>
    private static int GetBytes(string str, int index)
    {
        //checks if the index is not outside the range.
        if(index < str.Length)
        {
            //returns byte representation of the given symbol
            return (int)str[index];
        }

        return 0;
    }

    //Treats each four characters as an integer so
    //"aaaabbbb" hashes differently than "bbbbaaaa

    /// <summary>
    /// Gets encoded value for the given input through
    /// summing up an encoded value for for every 4 symbols(if any) 
    /// of the string input.</summary>
    /// <param name="input">String type value representing user input.</param>
    /// <returns>Returns integer type value representing encoded value of the input.</returns>
    private static int FoldingHash(string input)
    {
        //local integer-type-variable to sum the result.
        int hashValue = 0;

        //startpoint of every 4 symbols.
        int startIndex = 0;
        
        //local integer-type variable to carry every 4 symbols' encoded value.
        int currentFourBytes;

        //use do-while as at least one symbol(including space) should be an input.
        do
        {
            // get encoded value for every 4 byte
            currentFourBytes = GetNextBytes(startIndex, input);

            //will get back minus, if int.Max + 1
            unchecked
            {
                //get the summed-up value.
                hashValue += currentFourBytes;
            }

            //increment start value with 4, to reach the next 4 symbols.
            startIndex += 4;

        //if GetNextBytes function returns a value of zero the operation is over.   
        } while (currentFourBytes != 0);

        return hashValue;
    }
}