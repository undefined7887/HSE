internal static partial class Program
{
    private static int Factorial(int n)
    {
        var result = 1;
        for (var i = 1; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }
    
    private static bool IsInputNumberCorrect(int number)
    {
        return number >= 0;
    }
}