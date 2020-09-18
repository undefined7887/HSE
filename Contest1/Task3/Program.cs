using System;

namespace Task3
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // Contest compiler doesn't support "out var"
            int a;
            
            if (!ReadNonNegativeNumber(out a))
                return;
            
            Console.WriteLine(a % 10);
        }

        private static bool ReadNonNegativeNumber(out int number)
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out number) && number >= 0)
                return true;

            Console.WriteLine("Incorrect input");
            return false;
        }
    }
}