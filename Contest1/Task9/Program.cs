using System;

namespace Task9
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // Contest compiler doesn't support "out var"
            double a;

            if (!ReadDouble(out a))
                return;

            var decimalA = Math.Truncate(a);

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (Math.Abs(a - decimalA) == 0.5)
                Console.WriteLine(decimalA % 2 == 0 ? (decimalA > 0 ? decimalA + 1 : decimalA - 1) : decimalA);
            else
                Console.WriteLine((int) Math.Round(a));
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