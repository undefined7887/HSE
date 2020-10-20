using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CommandLib
{
    public class ListCommand : ICommandExecutable
    {
        public string GetDescription()
        {
            return "Retrieves all files and directories in current path";
        }

        public string GetHelp()
        {
            return $"Usage:{Environment.NewLine}" +
                   $"\tls{Environment.NewLine}" +
                   $"Description:{Environment.NewLine}" +
                   $"\t{GetDescription()}";
        }

        public void Execute(Context context, Command command)
        {
            string[] files, directories;

            try
            {
                files = Directory.GetFiles(context.Path);
                directories = Directory.GetDirectories(context.Path);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"Permission denied: {e.Message}");
                return;
            }
            catch (IOException e)
            {
                Console.WriteLine($"IO error occured: {e.Message}");
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to retrieve content: {e.Message}");
                return;
            }

            if (directories.Length != 0)
            {
                directories = directories
                    .Select(x => x.Split(Path.DirectorySeparatorChar).Last())
                    .ToArray();

                Console.WriteLine($"Directories:" +
                                  $"{Environment.NewLine}" +
                                  $"{string.Join(Environment.NewLine, directories.Select(x => "\t" + x))}");
            }

            // ReSharper disable once InvertIf
            if (files.Length != 0)
            {
                files = files
                    .Select(x => x.Split(Path.DirectorySeparatorChar).Last())
                    .ToArray();

                Console.WriteLine($"Files:" +
                                  $"{Environment.NewLine}" +
                                  $"{string.Join(Environment.NewLine, files.Select(x => "\t" + x))}");
            }
        }
    }
}