namespace PostFixCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                UseCalculator();
            }
        }

        /// <summary>
        /// Invokes Post Fix Calculator infinitely. 
        /// </summary>
        /// <returns>Returns true.</returns>
        static bool UseCalculator()
        {
            PostFixCalc calc = new PostFixCalc();
            return true;
        }
    }
}