using System;

namespace Task3
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            if (!GetIntFromUser(out var a))
                return;

            if (!GetIntFromUser(out var b))
                return;

            if (a >= b)
            {
                Console.WriteLine("Incorrect input");
                return;
            }

            for (var i = a; i < b; i++)
            {
                if (i % 2 == 0)
                    Console.WriteLine(i);
            }
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