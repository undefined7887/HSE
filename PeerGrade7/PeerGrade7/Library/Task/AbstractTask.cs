using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PeerGrade7.Library.Task
{
    [DataContract]
    public abstract class AbstractTask : Entity
    {
        [DataMember] public TaskStatus TaskStatus { get; set; }

        [DataMember] public DateTime CreatedAt { get; private set; }

        [DataMember] private List<AbstractTask> _tasks = new List<AbstractTask>();

        [DataMember] private List<User> _users = new List<User>();

        public int TasksLength => _tasks.Count;

        public int UsersLength => _users.Count;

        [DataMember] protected abstract string Type { get; set; }

        [DataMember] public abstract bool CanBeAssignedToSelf { get; protected set; }

        [DataMember] public abstract int TasksCount { get; protected set; }

        [DataMember] public abstract int UsersCount { get; protected set; }

        public AbstractTask(string name) : base(name)
        {
            TaskStatus = TaskStatus.Open;
            CreatedAt = DateTime.Now;
        }

        public void AddTask(AbstractTask task)
        {
            if (_tasks.Count == TasksCount)
                throw new InvalidOperationException("tasks capacity reached");

            if (!task.CanBeAssignedToSelf)
                throw new InvalidOperationException("this type of task can't be assigned");

            _tasks.Add(task);
        }

        public void RemoveTask(AbstractTask task)
        {
            _tasks.Remove(task);
        }

        public AbstractTask GetTask(int index) => _tasks[index];

        public void AddUser(User user)
        {
            if (_users.Count == UsersCount)
                throw new InvalidOperationException("users capacity reached");

            if (!_users.Contains(user))
                _users.Add(user);
        }

        public void RemoveUser(User user)
        {
            _users.Remove(user);
        }

        public User GetUser(int index) => _users[index];

        public override string ToString()
            => $"{Type} '{Name}' (status: {TaskStatus}, created at: {CreatedAt})";
    }
}