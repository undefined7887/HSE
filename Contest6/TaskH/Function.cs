using System;

public abstract class Function
{
    public static Function GetFunction(string functionName)
    {
        switch (functionName)
        {
            case "Sin":
                return new Sin();

            case "Exp":
                return new Exponent();

            case "Parabola":
                return new Parabola();

            default:
                throw new ArgumentException("Incorrect input");
        }
    }

    public abstract double GetValueInX(double x);

    public static double SolveIntegral(Function func, double left, double right, double step)
    {
        if (left > right)
            throw new ArgumentException("Left border greater than right");

        var leftX = func.GetValueInX(left);
        var rightX = func.GetValueInX(right);

        if (double.IsInfinity(leftX) || double.IsInfinity(rightX))
            throw new ArgumentException("Function is not defined in point");

        var result = 0.0;
        for (var i = left; i <= right; i += step)
        {
            var r1 = func.GetValueInX(i);

            double r2;
            if (i + step > right)
            {
                r2 = func.GetValueInX(right);
                result += (r1 + r2) / 2 * (right - i);
            }
            else
            {
                r2 = func.GetValueInX(i + step);
                result += (r1 + r2) / 2 * step;
            }
        }

        return result;
    }
}