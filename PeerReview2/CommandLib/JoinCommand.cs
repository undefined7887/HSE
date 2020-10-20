using System;
using System.IO;
using System.Linq;

namespace CommandLib
{
    public class JoinCommand : ICommandExecutable
    {
        public string GetDescription()
        {
            return "Concatenates 2 or more files in one file";
        }

        public string GetHelp()
        {
            return $"Usage:{Environment.NewLine}" +
                   $"\tjoin [filenames]... [output filename]{Environment.NewLine}" +
                   $"Description:{Environment.NewLine}" +
                   $"\t{GetDescription()}{Environment.NewLine}" +
                   $"Example:{Environment.NewLine}" +
                   $"\tjoin file1.txt file2.txt file3.txt";
        }

        public void Execute(Context context, Command command)
        {
            if (command.Arguments.Count < 3)
            {
                Console.WriteLine("You should pass at least 3 paths as arguments");
                return;
            }

            for (var i = 0; i < command.Arguments.Count; i++)
            {
                if (!Path.IsPathRooted(command.Arguments[i]))
                    command.Arguments[i] = Path.GetFullPath(Path.Join(context.Path, command.Arguments[i]));
            }

            try
            {
                var content = string.Empty;
                for (var i = 0; i < command.Arguments.Count - 1; i++)
                    content += File.ReadAllText(command.Arguments[i]);

                File.WriteAllText(command.Arguments.Last(), content);
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