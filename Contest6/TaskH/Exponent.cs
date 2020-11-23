using System;

public class Exponent : Function
{
    public override double GetValueInX(double x)
    {
        return Math.Pow(Math.E, 1 / x);
    }
}