using System;
using System.IO;

partial class Program
{
    private static string GetTextFromFile(string inputPath)
    {
        return File.ReadAllText(inputPath);
    }

    private static int GetSumFromText(string text)
    {
        var words = text.Split(
            new char[] {'\n', '\r', '.', '!', '?', ' ', ','}, 
            StringSplitOptions.RemoveEmptyEntries);

        var sum = 0;
        foreach (var word in words)
        {
            if (!int.TryParse(word, out var number))
                continue;

            sum += number;
        }

        return sum;
    }
}