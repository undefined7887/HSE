using System;
using System.Collections;

public class Worker
{
    private Apple[] _apples;

    public Worker(Apple[] apples)
    {
        _apples = apples;
    }

    public Apple[] GetSortedApples()
    {
        Array.Sort(_apples, Apple.Compare);
        return _apples;
    }
}