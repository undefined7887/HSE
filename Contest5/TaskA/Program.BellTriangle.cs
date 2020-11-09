using System;
using System.Collections.Generic;
using System.Text;

partial class Program
{
    static int[][] GetBellTriangle(uint rowCount)
    {
        var array = new int[rowCount][];

        var lastNumber = 1;
        for (var i = 0; i < rowCount; i++)
        {
            var lineLength = i + 1;

            var line = new int[lineLength];
            line[0] = lastNumber;

            for (var j = 1; j < lineLength; j++)
            {
                line[j] = array[i - 1][j - 1] + line[j - 1];

                if (j == i)
                    lastNumber = line[j];
            }

            array[i] = line;
        }

        return array;
    }

    private static void PrintJaggedArray(int[][] array)
    {
        foreach (var t in array)
        {
            foreach (var t1 in t)
                Console.Write(t1 + " ");

            Console.WriteLine();
        }
    }
}