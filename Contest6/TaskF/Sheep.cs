﻿using System;

public class Sheep
{
    public int Id { get; }
    public string Name { get; }
    private readonly string _sound;

    public Sheep(int id, string name, string sound)
    {
        if (id <= 0 || id >= 1000)
            throw new ArgumentException("Incorrect input");

        Id = id;
        Name = name;
        _sound = sound;
    }

    public override string ToString()
    {
        return $"[{Id}-{Name}]: {_sound}...{_sound}";
    }
}