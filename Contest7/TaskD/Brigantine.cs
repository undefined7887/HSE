using System;

class Brigantine : Boat
{
    public Brigantine(int value, bool isAtThePort) : base(value, isAtThePort)
    {
    }

    public new int CountCost(int weight)
    {
        if (weight < 500)
            return weight * Value * Value;

        return base.CountCost(weight);
    }
}