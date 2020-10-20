using System;
using System.IO;

namespace CommandLib
{
    public class RemoveCommand : ICommandExecutable
    {
        public string GetDescription()
        {
            return "Removes file or directory";
        }

        public string GetHelp()
        {
            return $"Usage:{Environment.NewLine}" +
                   $"\trm [filename/dirname]{Environment.NewLine}" +
                   $"Description:{Environment.NewLine}" +
                   $"\t{GetDescription()}{Environment.NewLine}" +
                   $"Example:{Environment.NewLine}" +
                   $"\trm index.txt";
        }

        public void Execute(Context context, Command command)
        {
            if (command.Arguments.Count == 0)
            {
                Console.WriteLine("You need to specify path as arguments");
                return;
            }

            if (!Path.IsPathRooted(command.Arguments[0]))
                command.Arguments[0] = Path.GetFullPath(Path.Join(context.Path, command.Arguments[0]));

            var isFile = File.Exists(command.Arguments[0]);

            try
            {
                if (isFile)
                    File.Delete(command.Arguments[0]);
                else
                    Directory.Delete(command.Arguments[0], true);
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
                Console.WriteLine($"Failed to remove content: {e.Message}");
            }
        }
    }
}