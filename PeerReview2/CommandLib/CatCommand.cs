using System;
using System.IO;
using System.Text;

namespace CommandLib
{
    public class CatCommand : ICommandExecutable
    {
        public string GetDescription()
        {
            return "Prints file content, possible encodings: -utf7, -utf8, -utf32, -ascii";
        }

        public string GetHelp()
        {
            return $"Usage:{Environment.NewLine}" +
                   $"\tcat [filename] <encoding>{Environment.NewLine}" +
                   $"Description:{Environment.NewLine}" +
                   $"\t{GetDescription()}{Environment.NewLine}" +
                   $"Example:{Environment.NewLine}" +
                   $"\tcat index.txt -utf32";
        }

        public void Execute(Context context, Command command)
        {
            if (command.Arguments.Count == 0)
            {
                Console.WriteLine("You need to specify filename as argument");
                return;
            }

            if (!Path.IsPathRooted(command.Arguments[0]))
                command.Arguments[0] = Path.GetFullPath(Path.Join(context.Path, command.Arguments[0]));

            try
            {
                var bytes = File.ReadAllBytes(command.Arguments[0]);
                var encoding = command.Flags.Count > 0 ? command.Flags[0].ToLower() : "-utf8";

                var content = encoding switch
                {
                    "-utf7" => Encoding.UTF7.GetString(bytes),
                    "-utf8" => Encoding.UTF8.GetString(bytes),
                    "-utf32" => Encoding.UTF32.GetString(bytes),
                    "-ascii" => Encoding.ASCII.GetString(bytes),
                    _ => string.Empty
                };

                Console.WriteLine($"{content}");
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
                Console.WriteLine($"Failed to read content from file: {e.Message}");
            }
        }
    }
}