using System;

namespace Task5
{
    internal static class Program
    {
        // Value must be even
        private const int NumberLength = 4;

        private static void Main(string[] args)
        {
            // Contest compiler doesn't support "out var"
            int number;

            var lowerLimit = Math.Pow(10, NumberLength - 1);
            var upperLimit = Math.Pow(10, NumberLength) - 1;

            var input = Console.ReadLine();
            if (input == null || !int.TryParse(input, out number) || number < lowerLimit || number > upperLimit)
            {
                Console.WriteLine("Incorrect input");
                return;
            }

            var result = true;
            for (var i = 0; i < NumberLength / 2; i++)
            {
                if (input[i] == input[NumberLength - i - 1])
                    continue;

                result = false;
                break;
            }

            // We only need "True" and "False" output
            Console.WriteLine(result ? "True" : "False");
        }
    }
}