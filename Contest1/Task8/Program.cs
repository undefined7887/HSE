using System;

namespace Task8
{
    internal static class Program
    {
        private const char LowerAlphabetLimit = 'a';
        private const char UpperAlphabetLimit = 'z';

        private static void Main(string[] args)
        {
            var input = Console.ReadLine();
            if (input == null || input.Length > 1 || input[0] < LowerAlphabetLimit || input[0] > UpperAlphabetLimit)
            {
                Console.WriteLine("Incorrect input");
                return;
            }
            
            Console.WriteLine(input[0] - LowerAlphabetLimit + 1);
        }
    }
}