using CustomHashTable;
namespace HashTableProject;

public class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            HashText();
        }
    }

    private static void HashText()
    {
        Console.Write("Input text for hashing: ");
        //run the hashing logic
        HashingLogic hashText = new HashingLogic(Console.ReadLine());
        

        // print final result of the calculation.
        Console.WriteLine("Your output: " + hashText.FinalCode);
    }
}