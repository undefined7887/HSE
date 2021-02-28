using System.Runtime.Serialization;

namespace PeerGrade7.Library
{
    /// <summary>
    /// Describes every entity in that project
    /// </summary>
    [DataContract]
    public abstract class Entity
    {
        /// <summary>
        /// Entity name
        /// </summary>
        [DataMember] public string Name { get; set; }

        protected Entity(string name)
        {
            Name = name;
        }
    }
}