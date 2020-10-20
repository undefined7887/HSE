using System;
using System.Collections.Generic;
using System.IO;

namespace CommandLib
{
    public class Context
    {
        /// <summary>
        /// Current path.
        /// </summary>
        public string Path { get; set; }

        public readonly Dictionary<string, ICommandExecutable> Commands 
            = new Dictionary<string, ICommandExecutable>();

        /// <summary>
        /// Inits context: fills commands dictionary & gets current program path
        /// </summary>
        public void Init()
        {
            try
            {
                Path = Directory.GetCurrentDirectory();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to get current program location: {e.Message}");
                Environment.Exit(1);
            }

            Commands.Add("help", new HelpCommand());
            Commands.Add("clear", new ClearCommand());
            Commands.Add("disks", new DisksCommand());
            Commands.Add("cd", new ChangeDirectoryCommand());
            Commands.Add("ls", new ListCommand());
            Commands.Add("mv", new MoveCommand());
            Commands.Add("cat", new CatCommand());
            Commands.Add("cp", new CopyCommand());
            Commands.Add("rm", new RemoveCommand());
            Commands.Add("nano", new NanoCommand());
            Commands.Add("join", new JoinCommand());
            Commands.Add("mkdir", new MakeDirectoryCommand());
        }
    }
}