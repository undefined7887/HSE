using System;


internal static partial class Program
{
    private static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        if (Validate(n))
        {
            Console.WriteLine(GetPerfectNumber(n));
        }
        else
            Console.WriteLine("Incorrect input");
    }
}