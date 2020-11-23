using System;
using System.Collections.Generic;
using System.Linq;

public class Grassland
{
    private readonly List<Sheep> _sheeps;

    public Grassland(List<Sheep> sheeps)
    {
        _sheeps = sheeps;
    }

    public List<Sheep> GetEvenSheeps()
    {
        return _sheeps
            .Where(x => x.Id % 2 == 0)
            .ToList();
    }

    public List<Sheep> GetOddSheeps()
    {
        return _sheeps
            .Where(x => x.Id % 2 != 0)
            .ToList();
    }

    public List<Sheep> GetSheepsByContainsName(string name)
    {
        return _sheeps
            .Where(x => x.Name.Contains(name))
            .ToList();
        ;
    }
}