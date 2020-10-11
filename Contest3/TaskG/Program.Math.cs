using System;
using System.Linq;

partial class Program
{
    private static double GetMin(double[] array)
    {
        return array.Min();
    }

    private static double GetAverage(double[] array)
    {
        return array.Average();
    }

    private static double GetMedian(double[] array)
    {
        Array.Sort(array);

        double result = 0;
        if (array.Length % 2 == 0)
            result = (array[array.Length / 2 - 1] + array[array.Length / 2]) / 2;
        else
            result = array[array.Length / 2];
        
        return result;
    }

    private static double[] ReadNumbers(string line)
    {
        var symbolArray = line.Split(' ');
        var doubleArray = new double[symbolArray.Length];

        for (var i = 0; i < symbolArray.Length; i++)
        {
            double.TryParse(symbolArray[i], out var number);
            doubleArray[i] = number;
        }

        return doubleArray;
    }
}