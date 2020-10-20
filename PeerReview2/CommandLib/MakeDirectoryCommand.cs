using System;
using System.IO;

namespace CommandLib
{
    public class MakeDirectoryCommand : ICommandExecutable
    {
        public string GetDescription()
        {
            return "Creates new directory";
        }

        public string GetHelp()
        {
            return $"Usage:{Environment.NewLine}" +
                   $"\tmkdir [dirname]{Environment.NewLine}" +
                   $"Description:{Environment.NewLine}" +
                   $"\t{GetDescription()}{Environment.NewLine}" +
                   $"Example:{Environment.NewLine}" +
                   $"\tmkdir dir";
        }

        public void Execute(Context context, Command command)
        {
            if (command.Arguments.Count == 0)
            {
                Console.WriteLine("You need to specify path as argument");
                return;
            }

            if (!Path.IsPathRooted(command.Arguments[0]))
                command.Arguments[0] = Path.GetFullPath(Path.Join(context.Path, command.Arguments[0]));

            try
            {
                Directory.CreateDirectory(command.Arguments[0]);
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