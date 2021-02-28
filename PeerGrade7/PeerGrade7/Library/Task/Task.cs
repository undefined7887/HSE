using System.Runtime.Serialization;

namespace PeerGrade7.Library.Task
{
    [DataContract]
    public class Task : AbstractTask
    {
        public Task(string name) : base(name)
        {
        }

        [DataMember] protected override string Type { get; set; } = "Task";
        [DataMember] public override bool CanBeAssignedToSelf { get; protected set; } = true;
        [DataMember] public override int TasksCount { get; protected set; }
        [DataMember] public override int UsersCount { get; protected set; } = 1;
    }
}