using System;
using System.Linq;

public class Snowflake
{
    private int _size;
    private int _branches;

    public Snowflake(int widthAndHeight, int raysCount)
    {
        if (widthAndHeight <= 0 
            || widthAndHeight % 2 == 0 
            || raysCount < 4 
            || Math.Log2(raysCount) % 1 != 0)
            throw new ArgumentException("Incorrect input");

        _size = widthAndHeight;
        _branches = raysCount;
    }

    public override string ToString()
    {
        var matrix = new char[_size, _size];
        DrawBaseBranches(matrix);
        DrawBranches(matrix, _branches - 4);

        var content = "";
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
                content += (matrix[i, j] == '*' ? '*' : ' ') + " ";

            content += Environment.NewLine;
        }

        return content.TrimEnd();
    }

    private static void DrawBaseBranches(char[,] matrix)
    {
        var length = matrix.GetLength(0);
        var index = length / 2;

        for (var i = 0; i < length; i++)
        {
            matrix[index, i] = '*';
            matrix[i, index] = '*';
        }
    }

    private static void DrawBranches(char[,] matrix, int count)
    {
        if (count == 0)
            return;
        
        var length = matrix.GetLength(0);

        var x = length / 2;
        var y = length / 2;
        
        DrawTopLeftBranch(matrix, x, y);
        DrawTopRightBranch(matrix, x, y);
        DrawBottomLeftBranch(matrix, x, y);
        DrawBottomRightBranch(matrix, x, y);

        count -= 4;

        var step = 1;
        while (count > 0)
        {
            DrawTopLeftBranch(matrix, x - 2 * step, y);
            DrawTopRightBranch(matrix, x - 2 * step, y);
            
            DrawTopRightBranch(matrix, x, y + 2 * step);
            DrawBottomRightBranch(matrix, x, y + 2 * step);
            
            DrawBottomLeftBranch(matrix, x + 2 * step, y);
            DrawBottomRightBranch(matrix, x + 2 * step, y);
            
            DrawTopLeftBranch(matrix, x, y - 2 * step);
            DrawBottomLeftBranch(matrix, x, y - 2 * step);

            count -= 8;
            step += 1;
        }
    }

    private static void DrawTopLeftBranch(char[,] matrix, int x, int y)
    {
        var length = Min(
            x, y,
            matrix.GetLength(0) - x - 1,
            matrix.GetLength(0) - y - 1
        );

        for (var i = 1; i <= length; i++)
            matrix[x - i, y - i] = '*';
    }

    private static void DrawTopRightBranch(char[,] matrix, int x, int y)
    {
        var length = Min(
            x, y,
            matrix.GetLength(0) - x - 1,
            matrix.GetLength(0) - y - 1
        );


        for (var i = 1; i <= length; i++)
            matrix[x - i, y + i] = '*';
    }

    private static void DrawBottomLeftBranch(char[,] matrix, int x, int y)
    {
        var length = Min(
            x, y,
            matrix.GetLength(0) - x - 1,
            matrix.GetLength(0) - y - 1
        );


        for (var i = 1; i <= length; i++)
            matrix[x + i, y - i] = '*';
    }

    private static void DrawBottomRightBranch(char[,] matrix, int x, int y)
    {
        var length = Min(
            x, y,
            matrix.GetLength(0) - x - 1,
            matrix.GetLength(0) - y - 1
        );


        for (var i = 1; i <= length; i++)
            matrix[x + i, y + i] = '*';
    }

    private static int Min(params int[] values)
        => values.Min();
}