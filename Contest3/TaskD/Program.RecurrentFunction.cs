partial class Program
{
    private static bool Validate(string input, out int num)
    {
        return int.TryParse(input, out num) && num >= 0;
    }

    private static int RecurrentFunction(int n)
    {
        return n == 0 ? 3 : 2 * (RecurrentFunction(n - 1) + 1);
    }
}