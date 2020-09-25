using System;

namespace Task1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            if (!GetPositiveIntFromUser(out var a)) 
                return;

            var sum = 0;
            while (Math.Abs(a) > 0)
            {
                sum += a % 10;
                a /= 10;
            }

            Console.WriteLine(sum);
        }

        private static bool GetPositiveIntFromUser(out int number)
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out number) && number > 0)
                return true;

            Console.WriteLine("Incorrect input");
            return false;
        }
    }
}