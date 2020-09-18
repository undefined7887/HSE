using System;

namespace Task2
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // Contest compiler doesn't support "out var"
            int a, b;
            
            if (!ReadNumber(out a))
                return;

            if (!ReadNumber(out b))
                return;

            Console.WriteLine(a - b);
        }

        private static bool ReadNumber(out int number)
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out number))
                return true;

            Console.WriteLine("Incorrect input");
            return false;
        }
    }
}