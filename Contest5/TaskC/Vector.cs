using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

partial class Program
{
    static bool TryParseVectorFromFile(string filename, out int[] vector)
    {
        var stringNumbers = File
            .ReadAllText(filename)
            .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

        vector = new int[stringNumbers.Length];
        for (var i = 0; i < vector.Length; i++)
        {
            if (!int.TryParse(stringNumbers[i], out var number))
                return false;

            vector[i] = number;
        }

        return true;
    }

    static int[,] MakeMatrixFromVector(int[] vector)
    {
        var result = new int[vector.Length, vector.Length];
        for (var i = 0; i < vector.Length; i++)
        for (var j = 0; j < vector.Length; j++)
            result[i, j] = vector[i] * vector[j];

        return result;
    }

    static void WriteMatrixToFile(int[,] matrix, string filename)
    {
        var content = string.Empty;

        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
                content += matrix[i, j] + " ";

            content = content.Trim() + Environment.NewLine;
        }

        File.WriteAllText(filename, content);
    }
}