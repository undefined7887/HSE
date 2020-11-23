using System;

public class Sin : Function
{
    public override double GetValueInX(double x)
    {
        return 1 / Math.Sin(x);
    }
}