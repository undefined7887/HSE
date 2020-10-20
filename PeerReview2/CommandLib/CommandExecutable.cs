namespace CommandLib
{
    public interface ICommandExecutable
    {
        /// <summary>
        /// Short info about command
        /// </summary>
        /// <returns>Command description</returns>
        string GetDescription();
        
        /// <summary>
        /// Full information about command
        /// </summary>
        /// <returns>Command help</returns>
        string GetHelp();

        /// <summary>
        /// Executes command from user
        /// </summary>
        /// <param name="context">Program context</param>
        /// <param name="command">Parsed command</param>
        void Execute(Context context, Command command);
    }
}