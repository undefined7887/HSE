using System;
using System.IO;

public class Wizard : LegendaryHuman
{
    private int _rank;
    private string _rankString;

    public Wizard(string name, int healthPoints, int power, string rank) : base(name, healthPoints, power)
    {
        _rank = rank switch
        {
            "Neophyte" => 1,
            "Adept" => 2,
            "Charmer" => 3,
            "Sorcerer" => 4,
            "Master" => 5,
            "Archmage" => 6,
            _ => throw new ArgumentException("Invalid wizard rank.")
        };

        _rankString = rank;
    }

    public override void Attack(LegendaryHuman enemy)
    {
        if (HealthPoints <= 0 || enemy.HealthPoints <= 0)
            return;
        
        Console.WriteLine($"{this} attacked {enemy}.");
        
        enemy.HealthPoints -= Power * (int) Math.Pow(_rank, 1.5) + HealthPoints / 10;
        if (enemy.HealthPoints <= 0)
            Console.WriteLine($"{enemy} is dead.");
    }

    public override string ToString()
    {
        return $"{_rankString} Wizard {Name} with HP {HealthPoints}";
    }
}