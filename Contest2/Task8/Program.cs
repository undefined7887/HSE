using System;


internal static partial class Program
{
    private static void Main(string[] args)
    {
        var dayOfWeek = Console.ReadLine();
        var firstNumberInput = int.Parse(Console.ReadLine());
        var secondNumberInput = int.Parse(Console.ReadLine());
        int result = MorningWorkout(dayOfWeek, firstNumberInput, secondNumberInput);
        if (result == int.MinValue)
            Console.WriteLine("Incorrect input");
        else
            Console.WriteLine(result);
    }
}