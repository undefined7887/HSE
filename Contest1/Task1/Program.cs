using System;

namespace Task1
{
    internal static class Program
    {
        private const int PrintCount = 3;

        private static void Main(string[] args)
        {
            var input = Console.ReadLine();

            for (var i = 0; i < PrintCount; i++)
                Console.WriteLine(input);
        }
    }
}