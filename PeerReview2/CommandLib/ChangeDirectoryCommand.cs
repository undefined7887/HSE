using System;
using System.IO;
using System.Linq;

namespace CommandLib
{
    public class ChangeDirectoryCommand : ICommandExecutable
    {
        public string GetDescription()
        {
            return "Changes current directory";
        }

        public string GetHelp()
        {
            return $"Usage:{Environment.NewLine}" +
                   $"\tcd [path]{Environment.NewLine}" +
                   $"Description:{Environment.NewLine}" +
                   $"\t{GetDescription()}{Environment.NewLine}" +
                   $"Example:{Environment.NewLine}" +
                   $"\tcd path/to/dir";
        }

        public void Execute(Context context, Command command)
        {
            if (command.Arguments.Count == 0)
            {
                Console.WriteLine("You need to specify path as argument");
                return;
            }
                

            if (Path.IsPathRooted(command.Arguments[0]) && Directory.Exists(command.Arguments[0]))
            {
                context.Path = OptimizePath(command.Arguments[0]);
                return;
            }

            var newPath = Path.Join(context.Path, command.Arguments[0]);
            if (Directory.Exists(newPath))
            {
                context.Path = OptimizePath(newPath);
                return;
            }

            Console.WriteLine("Wrong path specified");
        }

        private static string OptimizePath(string path)
        {
            path = Path.GetFullPath(path);

            if (!path.Equals("/") && path.Last().Equals('/'))
                path = path[..^1];

            return path;
        }
    }
}