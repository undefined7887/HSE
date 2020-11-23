using System;


public partial class Program
{
    static Sheep ParseSheep(string line)
    {
        var words = line.Split(' ');
        return new Sheep(int.Parse(words[4]), words[1], words[6]);
    }
}