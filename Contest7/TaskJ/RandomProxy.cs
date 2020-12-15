using System;
using System.Collections.Generic;
using System.IO;

class RandomProxy
{
    private StreamWriter _log;
    private Dictionary<string, int> _users = new Dictionary<string, int>();

    private static Random _random = new Random(1579);

    public RandomProxy(StreamWriter log)
    {
        _log = log;
    }

    public void Register(string login, int age)
    {
        if (_users.ContainsKey(login))
            throw new ArgumentException($"User {login}: login is already registered");

        _users[login] = age;
        _log.WriteLine($"User {login}: login registered");
    }

    public int Next(string login)
    {
        if (!_users.ContainsKey(login))
            throw new ArgumentException($"User {login}: login is not registered");

        var age = _users[login];

        if (age < 20)
        {
            var number = _random.Next(0, 1000);
            _log.WriteLine($"User {login}: generate number {number}");
            return number;
        }

        else
        {
            var number = _random.Next(0, int.MaxValue);
            _log.WriteLine($"User {login}: generate number {number}");
            return number;
        }
    }

    public int Next(string login, int maxValue)
    {
        if (!_users.ContainsKey(login))
            throw new ArgumentException($"User {login}: login is not registered");

        var age = _users[login];

        if (age < 20 && maxValue > 1000)
            throw new ArgumentOutOfRangeException($"User {login}: random bounds out of range");

        var number = _random.Next(0, maxValue);
        _log.WriteLine($"User {login}: generate number {number}");
        return number;
    }

    public int Next(string login, int minValue, int maxValue)
    {
        if (!_users.ContainsKey(login))
            throw new ArgumentException($"User {login}: login is not registered");

        var age = _users[login];

        if (age < 20 && maxValue - minValue > 1000)
            throw new ArgumentOutOfRangeException($"User {login}: random bounds out of range");

        var number = _random.Next(minValue, maxValue);
        _log.WriteLine($"User {login}: generate number {number}");
        return number;
    }
}