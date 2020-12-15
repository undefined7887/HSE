using System;

class Boat
{
    public bool IsAtThePort { get; }

    protected readonly int Value;

    public Boat(int value, bool isAtThePort)
    {
        IsAtThePort = isAtThePort;
        Value = value;
    }

    public int CountCost(int weight)
        => Value * weight;
}