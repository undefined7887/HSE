using System;

internal static partial class Program
{
    private static void Main(string[] args)
    {
        var a = double.Parse(Console.ReadLine());
        var b = double.Parse(Console.ReadLine());

        Console.WriteLine("{0}", Max(a, b));
    }
}