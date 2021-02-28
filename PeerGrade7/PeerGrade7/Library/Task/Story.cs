using System.Runtime.Serialization;

namespace PeerGrade7.Library.Task
{
    [DataContract]
    public class Story : AbstractTask
    {
        public Story(string name) : base(name)
        {
        }

        [DataMember] protected override string Type { get; set; } = "Story";
        [DataMember] public override bool CanBeAssignedToSelf { get; protected set; } = true;
        [DataMember] public override int TasksCount { get; protected set; }
        [DataMember] public override int UsersCount { get; protected set; } = int.MaxValue;
    }
}