using System;

public class Point
{
    public int X { get; }
    public int Y { get; }
    public int Z { get; }

    public Point(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;

        return obj is Point point
               && X.Equals(point.X)
               && Y.Equals(point.Y)
               && Z.Equals(point.Z);
    }

    public override int GetHashCode()
    {
        const int p = 31;
        var q = (int) Math.Pow(10, 9) + 7;

        return ((X + p * Y) % q + p * p * Z) % q;
    }

    public override string ToString()
        => $"{X} {Y} {Z}";
}