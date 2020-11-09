using System;
using System.IO;

internal class Matrix
{
    int[,] matrix;

    public Matrix(string filename)
    {
        var lines = File.ReadAllLines(filename);

        var height = lines.Length;
        var width = lines[0].Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries).Length;

        matrix = new int[height, width];

        for (var i = 0; i < lines.Length; i++)
        {
            var stringNumbers = lines[i].Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
            for (var j = 0; j < stringNumbers.Length; j++)
            {
                matrix[i, j] = int.Parse(stringNumbers[j]);
            }
        }
    }

    public int SumOffEvenElements
    {
        get
        {
            var sum = 0;
            foreach (var number in matrix)
            {
                if (number % 2 == 0)
                    sum += number;
            }

            return sum;
        }
    }


    public override string ToString()
    {
        var content = string.Empty;
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                if (j == matrix.GetLength(1) - 1)
                    content += matrix[i, j];
                else
                    content += matrix[i, j] + "\t";
            }

            content += Environment.NewLine;
        }

        return content;
    }
}