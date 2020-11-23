using System;

public class RegularPolygon : Polygon
{
    private readonly double _side;
    private readonly double _numberOfSides;

    public RegularPolygon(double side, int numberOfSides)
    {
        if (side <= 0)
            throw new ArgumentException("Side length value should be greater than zero.");

        if (numberOfSides < 3)
            throw new ArgumentException("Number of sides value should be greater than 3.");
        
        _side = side;
        _numberOfSides = numberOfSides;
    }

    public override double Perimeter
        => _side * _numberOfSides;

    public override double Area
        => (_numberOfSides * _side * _side) / (4 * Math.Tan(Math.PI / _numberOfSides));

    public override string ToString()
        => $"side: {_side}; numberOfSides: {_numberOfSides}; area: {Area:f3}; perimeter: {Perimeter:f3}";
}