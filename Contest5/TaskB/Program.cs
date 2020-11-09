using System;
using System.Collections.Generic;
using System.Linq;

internal static class Program
{
    private static void Main(string[] args)
    {
        var symbols = Console
            .ReadLine()?
            .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);

        PrintSymbols(symbols);
        for (var i = 0; i < symbols.Length - 1; i++)
            PrintSymbols(Shift(symbols));
    }

    private static string[] Shift(string[] array)
    {
        var first = array[0];
        for (var i = 0; i < array.Length - 1; i++)
            array[i] = array[i + 1];

        array[^1] = first;
        return array;
    }

    private static void PrintSymbols(string[] array)
    {
        Console.WriteLine(string.Join("", array));
    }
}