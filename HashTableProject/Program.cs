using CustomHashTable;
namespace HashTableProject;

public class Program
{
    static void Main(string[] args)
    {
        //optional string type input
        string input = "Once upon a time t";
        
        //run the hashing logic
        HashingLogic hashText = new HashingLogic(input);
        
        //print final result of the calculation.
        Console.WriteLine(hashText.FinalCode);
    }
}