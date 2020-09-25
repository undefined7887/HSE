using System;

internal partial class Program
{
    private static double MaxOfThree(double a, double b, double c)
    {
        return Math.Max(a, Math.Max(b, c));
    }
}