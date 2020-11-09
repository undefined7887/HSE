using System;

public class Triangle
{
    private readonly Point a;
    private readonly Point b;
    private readonly Point c;

    private double AB => GetLengthOfSide(a, b);
    private double AC => GetLengthOfSide(a, c);
    private double BC => GetLengthOfSide(b, c);

    private double HalfPerimeter => (AB + BC + AC) / 2;

    public Triangle(Point a, Point b, Point c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public double GetPerimeter()
    {
        return AB + AC + BC;
    }

    public double GetSquare()
    {
        return Math.Sqrt(HalfPerimeter * (HalfPerimeter - AB) * (HalfPerimeter - BC) * (HalfPerimeter - AC));
    }

    public bool GetAngleBetweenEqualsSides(out double angle)
    {
        if (AB == BC)
        {
            angle = GetAngle(a, b, c);
            return true;
        }

        if (BC == AC)
        {
            angle = GetAngle(a, c, b);
            return true;
        }

        if (AB == AC)
        {
            angle = GetAngle(b, a, c);
            return true;
        }

        angle = 0;
        return false;
    }

    public double GetAngle(Point a, Point b, Point c)
    {
        var ax = a.GetX() - b.GetX();
        var ay = a.GetY() - b.GetY();

        var bx = c.GetX() - b.GetX();
        var by = c.GetY() - b.GetY();

        return Math.Acos(
            (ax * bx + ay * by) /
            (Math.Sqrt(ax * ax + ay * ay) *
             Math.Sqrt(bx * bx + by * by))
        );
    }

    public bool GetHypotenuse(out double hypotenuse)
    {
        if (Math.Sqrt(AB * AB + BC * BC) == Math.Sqrt(AC * AC))
        {
            hypotenuse = AC;
            return true;
        }
        else if (Math.Sqrt(AB * AB + AC * AC) == Math.Sqrt(BC * BC))
        {
            hypotenuse = BC;
            return true;
        }
        else if (Math.Sqrt(BC * BC + AC * AC) == Math.Sqrt(AB * AB))
        {
            hypotenuse = AB;
            return true;
        }

        hypotenuse = 0;
        return false;
    }


    private static double GetLengthOfSide(Point first, Point second)
    {
        return Math.Sqrt(Math.Pow(first.GetX() - second.GetX(), 2) + Math.Pow(first.GetY() - second.GetY(), 2));
    }
}