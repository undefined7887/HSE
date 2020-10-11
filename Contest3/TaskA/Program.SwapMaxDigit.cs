partial class Program
{
    private static bool TryParseInput(string inputA, string inputB, out int a, out int b)
    {
        var parseResultA = int.TryParse(inputA, out a);
        var parseResultB = int.TryParse(inputB, out b);

        return parseResultA && parseResultB && a >= 0 && b >= 0;
    }

    private static void SwapMaxDigit(ref int a, ref int b)
    {
        var strA = a.ToString();
        var strB = b.ToString();

        var maxA = GetMaxDigit(strA);
        var maxB = GetMaxDigit(strB);

        strA = strA.Replace(maxA, maxB);
        strB = strB.Replace(maxB, maxA);

        int.TryParse(strA, out a);
        int.TryParse(strB, out b);
    }

    private static char GetMaxDigit(string number)
    {
        var result = '0';
        foreach (var digit in number)
        {
            if (digit > result)
                result = digit;
        }

        return result;
    }
}