using System;
using System.IO;

namespace CommandLib
{
    /// <summary>
    /// 
    /// </summary>
    public class CopyCommand : ICommandExecutable
    {
        public string GetDescription()
        {
            return "Creates file copy";
        }

        public string GetHelp()
        {
            return $"Usage:{Environment.NewLine}" +
                   $"\tcp [filename1] [filename2]{Environment.NewLine}" +
                   $"Description:{Environment.NewLine}" +
                   $"\t{GetDescription()}{Environment.NewLine}" +
                   $"Example:{Environment.NewLine}" +
                   $"\tcp file1.txt file2.txt";
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
                File.Copy(command.Arguments[0], command.Arguments[1]);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"Permission denied: {e.Message}");
            }
            catch (IOException e)
            {
                Console.WriteLine($"IO error occured: {e.GetType()} {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to copy content: {e.Message}");
            }
        }
    }
}