using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace PeerGrade7.Library
{
    /// <summary>
    /// Describes user
    /// </summary>
    [DataContract]
    public class User : Entity
    {
        public User(string name) : base(name)
        {
        }

        /// <summary>
        /// Renders list of users
        /// </summary>
        /// <param name="users">Users to render</param>
        /// <returns></returns>
        public static IEnumerable<string> RenderUsers(IEnumerable<User> users)
            => users.Select((t, i) => $"{i + 1}) {t}").ToList();

        public override string ToString()
            => $"User '{Name}'";
    }
}