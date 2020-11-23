using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class IntWrapper
{
    private int _number;

    public IntWrapper(int number)
    {
        _number = number;
    }

    public int FindNumberLength()
    {
        if (_number < 0)
            throw new ArgumentException("Number should be non-negative.");

        return _number.ToString().Length;
    }
}