using System;

internal static partial class Program
{
    private static void Main(string[] args)
    {
        var input = int.Parse(Console.ReadLine());
        if (!IsInputNumberCorrect(input))
        {
            Console.WriteLine("Incorrect input");
            return;
        }
        Console.WriteLine(Factorial(input));
    }
}