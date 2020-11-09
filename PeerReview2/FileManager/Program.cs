using System;
using System.IO;
using System.Linq;
using CommandLib;

namespace FileManager
{
    internal static class Program
    {
        private static readonly Context Context
            = new Context();

        /// <summary>
        /// Simple FileManager.
        /// </summary>
        private static void Main()
        {
            Context.Init();
            Observe();
        }

        /// <summary>
        /// Main application loop.
        /// </summary>
        private static void Observe()
        {
            // Prints first help message
            new HelpCommand().Execute(Context, Command.Parse(string.Empty));

            while (true)
            {
                var command = Command.Parse(GetUserInput(OptimizePath(Context.Path)));

                if (!Context.Commands.ContainsKey(command.Name))
                {
                    Console.WriteLine($"Command not found");
                    continue;
                }

                Context.Commands[command.Name].Execute(Context, command);
            }
        }

        /// <summary>
        /// Compresses path to last two directories.
        /// </summary>
        /// <param name="path">Path to compress</param>
        /// <returns>Compressed path</returns>
        private static string OptimizePath(string path)
        {
            var splitPath = path
                .Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries);

            return splitPath.Length < 3
                ? path
                : string.Join(Path.DirectorySeparatorChar, splitPath.Skip(splitPath.Length - 2));
        }

        /// <summary>
        /// Reads user input.
        /// </summary>
        /// <param name="prefix">String to be printed at the beginning of the line</param>
        /// <returns>User input</returns>
        private static string GetUserInput(string prefix)
        {
            Console.Write($"[{prefix}]$ ");
            return Console.ReadLine();
        }
    }
}