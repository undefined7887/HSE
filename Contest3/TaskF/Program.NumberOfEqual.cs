using System.Collections.Generic;

partial class Program
{
    private static int[] ParseInput(string input)
    {
        var symbolArray = input.Split(' ');
        var numberArray = new int[symbolArray.Length];

        for (var i = 0; i < symbolArray.Length; i++)
        {
            int.TryParse(symbolArray[i], out var number);
            numberArray[i] = number;
        }

        return numberArray;
    }

    private static int GetNumberOfEqualElements(int[] first, int[] second)
    {
        var firstHashSet = new HashSet<int>();
        foreach (var number in first)
            firstHashSet.Add(number);

        var count = 0;
        foreach (var number in second)
        {
            if (firstHashSet.Contains(number))
                count++;
        }

        return count;
    }
}