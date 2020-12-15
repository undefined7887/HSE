using System;

class Linguist : Editor
{
    private readonly string _bannedWord;

    private Linguist(string name, int salary, string bannedWord) : base(name, salary)
    {
        _bannedWord = bannedWord;
    }

    public new string EditHeader(string header)
    {
        return base.EditHeader(header.Replace(_bannedWord, ""));
    }

    public static Linguist Parse(string line)
    {
        var words = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        if (words.Length != 3
            || !int.TryParse(words[1], out var payment)
            || payment < 0)
            throw new ArgumentException("Incorrect input");

        return new Linguist(words[0], payment, words[2]);
    }
}