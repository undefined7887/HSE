using System;
using System.IO;
using System.Text;

namespace CommandLib
{
    public class NanoCommand : ICommandExecutable
    {
        public string GetDescription()
        {
            return "Creates and writes some data to the file, possible encodings: -utf7, -utf8, -utf32, -ascii";
        }

        public string GetHelp()
        {
            return $"Usage:{Environment.NewLine}" +
                   $"\tnano [filename] <encoding>{Environment.NewLine}" +
                   $"Description:{Environment.NewLine}" +
                   $"\t{GetDescription()}{Environment.NewLine}" +
                   $"Example:{Environment.NewLine}" +
                   $"\tnano text.txt -utf32";
        }

        public void Execute(Context context, Command command)
        {
            if (command.Arguments.Count == 0)
            {
                Console.WriteLine("You need to specify 2 paths as arguments");
                return;
            }

            if (!Path.IsPathRooted(command.Arguments[0]))
                command.Arguments[0] = Path.GetFullPath(Path.Join(context.Path, command.Arguments[0]));

            var encoding = command.Flags.Count > 0 ? command.Flags[0].ToLower() : "-utf8";
            var encodingObject = encoding switch
            {
                "-utf7" => Encoding.UTF7,
                "-utf8" => Encoding.UTF8,
                "-utf32" => Encoding.UTF32,
                "-ascii" => Encoding.ASCII,
                _ => Encoding.UTF8
            };

            if (File.Exists(command.Arguments[0]))
            {
                Console.WriteLine($"File already exists");
                return;
            }

            try
            {
                OpenFileEditor(File.Create(command.Arguments[0]), encodingObject);
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

        private static void OpenFileEditor(Stream file, Encoding encoding)
        {
            Console.Clear();
            Console.WriteLine("Write something here, " +
                              "if you want to continue press ENTER twice, " +
                              "if you want quit press ENTER and ESC");

            var sw = new StreamWriter(file, encoding);
            do
            {
                sw.WriteLine(Console.ReadLine());
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            try
            {
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to close file: {e.Message}");
            }

            // This two calls are necessary
            Console.Clear();
            Console.Clear();
        }
    }
}