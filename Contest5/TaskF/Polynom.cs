using System;
using System.Linq;

class Polynom
{
    public static bool TryParsePolynom(string line, out int[] arr)
    {
        var stringNumbers = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        arr = new int[stringNumbers.Length];

        for (var i = 0; i < stringNumbers.Length; i++)
        {
            if (!int.TryParse(stringNumbers[i], out var number))
                return false;

            arr[i] = number;
        }

        return true;
    }

    public static int[] Sum(int[] a, int[] b)
    {
        var len = Math.Max(a.Length, b.Length);
        var result = new int[len];

        for (var i = 0; i < result.Length; i++)
            result[i] = (i < a.Length ? a[i] : 0) + (i < b.Length ? b[i] : 0);

        return result;
    }

    public static int[] Dif(int[] a, int[] b)
    {
        return Sum(a, MultiplyByNumber(b, -1));
    }

    public static int[] MultiplyByNumber(int[] a, int n)
    {
        return a.Select(x => n * x).ToArray();
    }

    public static int[] MultiplyByPolynom(int[] a, int[] b)
    {
        var len = a.Length + b.Length - 1;
        var result = new int[len];

        for (var i = 0; i < len; i++)
        {
            for (var j = 0; j < a.Length; j++)
            for (var k = 0; k < b.Length; k++)
            {
                if (j + k != i)
                    continue;
                result[i] += a[j] * b[k];
            }
        }

        return result;
    }

    public static string PolynomToString(int[] polynom)
    {
        var result = string.Empty;
        for (var i = polynom.Length - 1; i >= 0; i--)
        {
            var elem = string.Empty;

            if (polynom[i] == 0)
                continue;

            if (!result.Equals(string.Empty))
                elem += " + ";

            elem += i switch
            {
                1 when polynom[i] == 1 => "x",
                1 => polynom[i] + "x",
                0 => polynom[i],
                _ => polynom[i] + "x" + i
            };

            result += elem;
        }

        if (result.Equals(string.Empty))
            result = "0";

        return result;
    }
}