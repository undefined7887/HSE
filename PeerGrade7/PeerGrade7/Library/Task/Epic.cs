using System.Runtime.Serialization;

namespace PeerGrade7.Library.Task
{
    [DataContract]
    public class Epic : AbstractTask
    {
        public Epic(string name) : base(name)
        {
        }

        [DataMember] protected override string Type { get; set; } = "Epic";

        [DataMember] public override bool CanBeAssignedToSelf { get; protected set; }

        [DataMember] public override int TasksCount { get; protected set; } = int.MaxValue;

        [DataMember] public override int UsersCount { get; protected set; }
    }
}