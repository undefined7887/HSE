namespace PeerGrade7
{
    /// <summary>
    /// Container for app state
    /// </summary>
    public class StateContainer
    {
        /// <summary>
        /// App state
        /// </summary>
        public State State { get; }
        
        /// <summary>
        /// State data
        /// </summary>
        public object Data { get; }

        public StateContainer(State state, object data)
        {
            State = state;
            Data = data;
        }
    }
}