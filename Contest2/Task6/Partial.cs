internal static partial class Program
{
    private static bool Validate(int n)
    {
        return n >= 0;
    }

    private static int DivisorsSum(int n)
    {
        var result = 0;
        for (var i = 1; i <= n / 2; i++)
        {
            if (n % i == 0)
                result += i;
        }

        return result;
    }
}