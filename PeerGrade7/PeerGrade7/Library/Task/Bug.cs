using System.Runtime.Serialization;

namespace PeerGrade7.Library.Task
{
    [DataContract]
    public class Bug : AbstractTask
    {
        public Bug(string name) : base(name)
        {
        }

        [DataMember] protected override string Type { get; set; } = "Bug";

        [DataMember] public override bool CanBeAssignedToSelf { get; protected set; }

        [DataMember] public override int TasksCount { get; protected set; }

        [DataMember] public override int UsersCount { get; protected set; } = 1;
    }
}