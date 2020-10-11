using System.Linq;

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

    private static int GetMaxInArray(int[] numberArray)
    {
        return numberArray.Max();
    }
}