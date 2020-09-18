using System;

namespace Task7
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // Contest compiler doesn't support "out var"
            double a;

            if (!ReadNonNegativeDouble(out a))
                return;

            Console.WriteLine((int) (a * 10) % 10);
        }

        private static bool ReadNonNegativeDouble(out double number)
        {
            var input = Console.ReadLine();
            if (double.TryParse(input, out number) && number >= 0)
                return true;

            Console.WriteLine("Incorrect input");
            return false;
        }
    }
}