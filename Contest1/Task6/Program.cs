using System;

namespace Task6
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // Contest compiler doesn't support "out var"
            double a, b;

            if (!ReadPositiveDouble(out a))
                return;

            if (!ReadPositiveDouble(out b))
                return;

            Console.WriteLine("{0:F5}", Math.Sqrt(a * a + b * b));
        }

        private static bool ReadPositiveDouble(out double number)
        {
            var input = Console.ReadLine();
            if (double.TryParse(input, out number) && number > 0)
                return true;

            Console.WriteLine("Incorrect input");
            return false;
        }
    }
}