using System;
using System.Collections.Generic;

public partial class TestSystem
{
    private List<User> _users = new List<User>();

    public void Add(string username)
    {
        var index = -1;
        for (var i = 0; i < _users.Count; i++)
        {
            if (_users[i].Nickname.Equals(username))
            {
                index = i;
                break;
            }
        }

        if (index != -1)
        {
            if (_users[index].Active)
                throw new ArgumentException("User already exists");

            _users[index].Active = true;
            Notifications += _users[index].SendMessage;
        }
        else
        {
            var newUser = new User(username);
            _users.Add(newUser);
            Notifications += newUser.SendMessage;
        }
    }

    public void Remove(string username)
    {
        var index = -1;
        for (var i = 0; i < _users.Count; i++)
        {
            if (_users[i].Nickname.Equals(username))
            {
                index = i;
                break;
            }
        }

        if (index == -1)
            throw new ArgumentException("User does not exist");
        
        _users[index].Active = false;
        Notifications -= _users[index].SendMessage;
    }
}