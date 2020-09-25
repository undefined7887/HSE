using System;


internal static partial class Program
{
    static void Main(string[] args)
    {
        var a = double.Parse(Console.ReadLine());
        var b = double.Parse(Console.ReadLine());
        var c = double.Parse(Console.ReadLine());

        Console.WriteLine(MaxOfThree(a, b, c));
    }
}