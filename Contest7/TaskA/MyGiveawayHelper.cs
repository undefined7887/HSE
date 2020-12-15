using System;
using System.Collections.Generic;
using System.Linq;

internal class MyGiveawayHelper
{
    private string[] _prizes;
    private int _prizesIndex;

    private string[] _logins;

    private int _currentNumber = 1579;

    public MyGiveawayHelper(string[] logins, string[] prizes)
    {
        _prizes = prizes;
        _logins = logins;
    }

    public bool HasPrizes
        => _prizesIndex != _prizes.Length;

    private void UpdateCurrentNumber()
    {
        _currentNumber = _currentNumber * _currentNumber / 100 % 10000;
    }

    public (string prize, string login) GetPrizeLogin()
    {
        UpdateCurrentNumber();
        return (_prizes[_prizesIndex++], _logins[_currentNumber % _logins.Length]);
    }
}