internal partial class Program
{
    private static bool Validate(int a)
    {
        return a > 0;
    }

    private static int GetPerfectNumber(int a)
    {
        var i = a;
        while (!IsPerfect(i))
            i++;

        return i;
    }

    private static bool IsPerfect(int a)
    {
        var sum = 0;
        for (var i = 1; i <= a / 2; i++)
        {
            if (a % i == 0)
                sum += i;
        }

        return sum == a;
    }
}