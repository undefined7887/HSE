using System;
using System.IO;

namespace CommandLib
{
    public class MoveCommand : ICommandExecutable
    {
        public string GetDescription()
        {
            return "Moves file or directory to the new location";
        }

        public string GetHelp()
        {
            return $"Usage:{Environment.NewLine}" +
                   $"\tmv [path] [path]{Environment.NewLine}" +
                   $"Description:{Environment.NewLine}" +
                   $"\t{GetDescription()}{Environment.NewLine}" +
                   $"Example:{Environment.NewLine}" +
                   $"\tmv index.txt index2.txt{Environment.NewLine}" +
                   $"\tmv dirname1 dirname2";
        }

        public void Execute(Context context, Command command)
        {
            if (command.Arguments.Count < 2)
            {
                Console.WriteLine("You need to specify 2 paths as arguments");
                return;
            }

            for (var i = 0; i < command.Arguments.Count; i++)
            {
                if (!Path.IsPathRooted(command.Arguments[i]))
                    command.Arguments[i] = Path.GetFullPath(Path.Join(context.Path, command.Arguments[i]));
            }

            try
            {
                Directory.Move(command.Arguments[0], command.Arguments[1]);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"Permission denied: {e.Message}");
            }
            catch (IOException e)
            {
                Console.WriteLine($"IO error occured: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to move content: {e.Message}");
            }
        }
    }
}