using System;
using System.Linq;

partial class Program
{
    private static int GetCountGreaterThanValue(int[] array, double average)
    {
        return array.Count(number => number > average);
    }

    private static double GetAverage(int[] array)
    {
        return (double) array.Sum() / array.Length;
    }

    private static bool ValidateNumber(out int n)
    {
        return int.TryParse(Console.ReadLine(), out n) && n >= 0;
    }

    private static bool ReadNumbers(int n, out int[] array)
    {
        array = new int[n];

        for (var i = 0; i < n; i++)
        {
            var input = Console.ReadLine();
            if (!int.TryParse(input, out var arrayNumber) || arrayNumber < 0)
                return false;

            array[i] = arrayNumber;
        }

        return true;
    }
}