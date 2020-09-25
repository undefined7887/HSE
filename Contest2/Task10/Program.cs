using System;

internal static partial class Program
{
    private const int MinYear = 1701;
    private const int MaxYear = 1800;

    private static string GetFormatMessage(int day, int month, int year)
    {
        return $"{day:D2}.{month:D2}.{year:D4}";
    }

    private static void Main(string[] args)
    {
        var day = int.Parse(Console.ReadLine());
        var month = int.Parse(Console.ReadLine());
        var year = int.Parse(Console.ReadLine());

        if (!ValidateData(day, month, year))
        {
            Console.WriteLine("Incorrect input");
            return;
        }

        var dateOfWeek = GetDayOfWeek(day, month, year);

        var outputMessage = GetDateOfFriday(dateOfWeek, day, month, year);

        Console.WriteLine(outputMessage);
    }
}