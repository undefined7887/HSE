using System;

namespace Task2
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var number = 1337_228;
            var sum = 0;
            while (number != 0) {
                var success = GetIntFromUser(out number);
                if (!success) {
                    return;
                }
              
                if (number % 2 != 0) {
                    sum += number;
                }
            }

            Console.WriteLine(sum);
        }

        private static bool GetIntFromUser(out int number)
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out number))
                return true;

            Console.WriteLine("Incorrect input");
            return false;
        }
    }
}