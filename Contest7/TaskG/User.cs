using System;
using System.Collections.Generic;

public class User
{
    private List<string> _messages = new List<string>();

    public bool Active { get; set; } = true;

    public string Nickname { get; }

    public User(string username)
    {
        Nickname = username;
    }

    public override string ToString()
    {
        var content = $"-{Nickname}-";
        if (_messages.Count == 0)
            return content;

        content += $"{Environment.NewLine}Received notifications:{Environment.NewLine}";

        for (var i = 0; i < _messages.Count; i++)
            content += $"{_messages[i]}{Environment.NewLine}";

        return content.TrimEnd();
    }

    public void SendMessage(string text)
    {
        Console.WriteLine(this);
        Console.WriteLine($"New notification: {text}");

        _messages.Add(text);
    }
}