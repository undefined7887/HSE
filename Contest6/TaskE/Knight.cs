using System;
using System.IO;

public class Knight : LegendaryHuman
{
    private string[] _equipment;

    public Knight(string name, int healthPoints, int power, string[] equipment) : base(name, healthPoints, power)
    {
        if (equipment.Length == 0)
            throw new ArgumentException("Not enough equipment.");
        
        _equipment = equipment;
    }

    public override void Attack(LegendaryHuman enemy)
    {
        if (HealthPoints <= 0 || enemy.HealthPoints <= 0)
            return;
        
        Console.WriteLine($"{this} attacked {enemy}.");
        
        enemy.HealthPoints -= Power + 10 * _equipment.Length;
        if (enemy.HealthPoints <= 0)
            Console.WriteLine($"{enemy} is dead.");
    }
    
    public override string ToString()
    {
        return $"Knight {Name} with HP {HealthPoints}";
    }
}