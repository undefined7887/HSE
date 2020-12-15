using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public partial class Program
{
    /// <summary>
    /// Считывает точки в список.
    /// </summary>
    /// <returns>Список точек.</returns>
    private static List<Point> GetPoints()
    {
        var lines = File.ReadAllLines(InputPath);

        return lines
            .Select(line => line.Split(" ", StringSplitOptions.RemoveEmptyEntries))
            .Select(splitLine =>
                new Point(
                    int.Parse(splitLine[0]),
                    int.Parse(splitLine[1]),
                    int.Parse(splitLine[2])
                )
            ).ToList();
    }


    /// <summary>
    /// Получает коллекцию уникальных точек.
    /// </summary>
    /// <param name="points">Список исходных точек.</param>
    /// <returns>Коллекция точек.</returns>
    private static HashSet<Point> GetUnique(List<Point> points)
        => new HashSet<Point>(points);
}