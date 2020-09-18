using System;

namespace Task10
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // Contest compiler doesn't support "out var"
            double x, y;

            if (!ReadDouble(out x))
                return;

            if (!ReadDouble(out y))
                return;

            var sum = x * x + y * y;

            // We only need "True" and "False" output
            Console.WriteLine(sum >= 1 && sum <= 2 ? "True" : "False");
        }

        private static bool ReadDouble(out double number)
        {
            var input = Console.ReadLine();
            if (double.TryParse(input, out number))
                return true;

            Console.WriteLine("Incorrect input");
            return false;
        }
    }
}