using System;
using System.Collections.Generic;
#pragma warning disable

public class ArchaeologicalFind
{
    private int _index;
    private readonly int _age;
    private readonly int _weight;
    private readonly string _name;

    public static int TotalFindsNumber;
    
    public ArchaeologicalFind(int age, int weight, string name)
    {
        if (age <= 0)
            throw new ArgumentException("Incorrect age");
        
        if (weight <= 0)
            throw new ArgumentException("Incorrect weight");

        if (name.Equals("?"))
            throw new ArgumentException("Undefined name");
        
        _age = age;
        _weight = weight;
        _name = name;
    }
    
    /// <summary>
    /// Добавляет находку в список.
    /// </summary>
    /// <param name="finds">Список находок.</param>
    /// <param name="archaeologicalFind">Находка.</param>
    public static void AddFind(ICollection<ArchaeologicalFind> finds, ArchaeologicalFind archaeologicalFind)
    {
        TotalFindsNumber++;

        if (finds.Contains(archaeologicalFind)) 
            return;
        
        archaeologicalFind._index = TotalFindsNumber - 1;
        finds.Add(archaeologicalFind);
    }


    public override bool Equals(object obj)
    {
        return obj is ArchaeologicalFind find
               && _age.Equals(find._age)
               && _name.Equals(find._name)
               && _weight.Equals(find._weight);
    }
    
    public override string ToString() 
        => $"{_index} {_name} {_age} {_weight}";
}