using System;

public class Apple
{
    private string _color;
    private double _weight;

    public double Weight
    {
        get => _weight;
        set
        {
            if (value <= 0 || value > 1000)
                throw new ArgumentException("Incorrect input");

            _weight = value;
        }
    }

    public string Color
    {
        get => _color;
        set
        {
            if (value.Length > 5 || 'a' <= value[0] && value[0] <= 'z')
                throw new ArgumentException("Incorrect input");

            _color = value;
        }
    }

    public override string ToString()
    {
        return $"{_color} Apple. Weight = {_weight:f2}g.";
    }
    
    public static int Compare(Apple a1, Apple a2)
    {
        return a1.Weight.CompareTo(a2.Weight);
    }
}