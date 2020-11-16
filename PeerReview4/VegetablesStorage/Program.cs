using System;
using System.Collections.Generic;
using System.IO;

namespace VegetablesStorage
{
    internal static class Program
    {
        /// <summary>
        /// Program "Vegetables storage"
        /// </summary>
        private static void Main()
        {
            while (true)
                MainMenu();
        }

        /// <summary>
        /// Main menu
        /// </summary>
        private static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose action:");
            Console.WriteLine("\t1) Create storage from cli");
            Console.WriteLine("\t2) Create storage from file");
            Console.WriteLine("\t3) Exit");

            while (true)
            {
                var action = GetPositiveIntFromUser("Action:", false);
                switch (action)
                {
                    case 1:
                        CreateStorageFromUser();
                        while (Observe())
                        {
                        }

                        return;

                    case 2:
                        CreateStorageFromFile();
                        while (Observe())
                        {
                        }

                        return;
                    case 3:
                        Environment.Exit(0);
                        return;

                    default:
                        Console.WriteLine("Wrong action");
                        continue;
                }
            }
        }

        /// <summary>
        /// Creates storage from user input
        /// </summary>
        private static void CreateStorageFromUser()
        {
            Console.Clear();
            Console.WriteLine("Let's create new storage, please enter some info about it:");

            var capacity = GetPositiveIntFromUser("Storage capacity (containers count):", false);
            var containerCost = GetPositiveDoubleFromUser("Storage container cost:", false);

            Storage.Singleton = new Storage(capacity, containerCost);
        }

        /// <summary>
        /// Creates storage from file
        /// </summary>
        private static void CreateStorageFromFile()
        {
            Console.Clear();
            Console.WriteLine("Enter path to file, that contains information about storage.");
            Console.WriteLine("Format should be: capacity;containerCost");

            while (true)
            {
                Console.Write("Path: ");
                var path = Console.ReadLine();

                string content;
                try
                {
                    content = File.ReadAllText(path);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Wrong path: {e.Message}");
                    continue;
                }

                var splitString = content.Split(';', StringSplitOptions.RemoveEmptyEntries);
                if (splitString.Length != 2)
                {
                    Console.WriteLine("Wrong file format");
                    continue;
                }

                if (!int.TryParse(splitString[0], out var capacity)
                    || capacity < 1
                    || !double.TryParse(splitString[1], out var containerCost)
                    || containerCost <= 0)
                {
                    Console.WriteLine("Wrong file format");
                    continue;
                }

                Storage.Singleton = new Storage(capacity, containerCost);
                break;
            }
        }

        /// <summary>
        /// Storage actions
        /// </summary>
        /// <returns>False if user wants to exit to main menu</returns>
        private static bool Observe()
        {
            Console.Clear();
            Console.WriteLine("Current storage:");
            Console.WriteLine(Storage.Singleton);

            Console.WriteLine();
            Console.WriteLine("Choose action:");
            Console.WriteLine("\t1) Add container");
            Console.WriteLine("\t2) Remove container");
            Console.WriteLine("\t3) Get commands from file");
            Console.WriteLine("\t4) Write storage to file");
            Console.WriteLine("\t5) Return to main menu");

            while (true)
            {
                var action = GetPositiveIntFromUser("Action:", false);
                switch (action)
                {
                    case 1:
                        AddContainer();
                        return true;

                    case 2:
                        RemoveContainer();
                        return true;

                    case 3:
                        CompileFileTasks();
                        return true;

                    case 4:
                        WriteStorageToFile();
                        return true;

                    case 5:
                        return false;

                    default:
                        Console.WriteLine("Wrong action");
                        continue;
                }
            }
        }

        /// <summary>
        /// Adds container specified by the user
        /// </summary>
        private static void AddContainer()
        {
            var container = GetContainerFromUser();
            if (Storage.Singleton.AddContainer(container))
                return;

            Console.WriteLine(
                $"Container wasn't added due to its unprofitability (Storage ContainerCost: {Storage.Singleton.ContainerCost})");
            Console.WriteLine(container.ToString(1) + Environment.NewLine);
            Console.WriteLine("Press ANY key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Removes container specified by the user
        /// </summary>
        private static void RemoveContainer()
        {
            Storage.Singleton.RemoveContainer(
                GetPositiveIntFromUser("Index to remove:", true));
        }

        /// <summary>
        /// Gets container from command line
        /// </summary>
        /// <returns>Container from user</returns>
        private static Container GetContainerFromUser()
        {
            Console.Clear();
            Console.WriteLine(
                "Enter boxes in format: <box 1 weight>;<box 1 weightCost>;<box 2 weight>;<box 2 weightCost>...");
            while (true)
            {
                var line = Console.ReadLine();

                var container = Container.Parse(line);
                if (container != null)
                {
                    Console.Clear();
                    return container;
                }

                Console.Clear();
                Console.WriteLine("Wrong input");
            }
        }

        /// <summary>
        /// Writes storage to file
        /// </summary>
        private static void WriteStorageToFile()
        {
            WriteContentToFile("Path:", Storage.Singleton.ToString());
        }

        /// <summary>
        /// Parses commands from file and executes them
        /// </summary>
        /// <returns></returns>
        private static void CompileFileTasks()
        {
            Console.Clear();
            Console.WriteLine(
                "Enter 2 paths. First path to file with containers and second path to file with commands.");
            Console.WriteLine("The containers file must contain a description of the containers, each on a new line.");
            Console.WriteLine("Container format: <box 1 weight>;<box 1 weightCost>;<box 2 weight>;<box 2 weightCost>");

            Console.WriteLine();
            Console.WriteLine("The commands file must contain a list of commands, each on a new line.");
            Console.WriteLine("Possible commands:");
            Console.WriteLine(
                "\tadd <index> - Adds container. Index points to container in containers file. Starts from 0");
            Console.WriteLine(
                "\tremove <index> - Removes container. Index points to container in storage. Starts from 0");

            var containers = ParseContainersFile();
            var commands = ParseCommandsFile();

            foreach (var command in commands)
            {
                switch (command.Name)
                {
                    case "add":
                        if (commands.Count <= command.Parameter)
                            continue;

                        Storage.Singleton.AddContainer(containers[command.Parameter]);
                        break;

                    case "remove":
                        Storage.Singleton.RemoveContainer(command.Parameter);
                        break;
                }
            }
        }

        /// <summary>
        /// Parses containers file
        /// </summary>
        /// <returns>Parsed commands</returns>
        private static List<Container> ParseContainersFile()
        {
            while (true)
            {
                var lines = GetFileContent("Containers file path:")
                    .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

                var result = new List<Container>();

                var flag = false;
                foreach (var line in lines)
                {
                    var container = Container.Parse(line);
                    if (container == null)
                    {
                        flag = true;
                        Console.WriteLine("Wrong file format");
                        break;
                    }

                    result.Add(container);
                }

                if (flag)
                    continue;

                return result;
            }
        }

        /// <summary>
        /// Parses commands file
        /// </summary>
        /// <returns>Parsed commands</returns>
        private static List<Command> ParseCommandsFile()
        {
            while (true)
            {
                var lines = GetFileContent("Commands file path:")
                    .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

                var result = new List<Command>();
                
                var flag = false;
                foreach (var line in lines)
                {
                    var command = Command.Parse(line);
                    if (command == null)
                    {
                        flag = true;
                        Console.WriteLine("Wrong file format");
                        continue;
                    }

                    result.Add(command);
                }

                if (flag)
                    continue;

                return result;
            }
        }

        /// <summary>
        /// Reads content from file
        /// </summary>
        /// <param name="prefix">Prefix to print before path</param>
        /// <returns>Content from file</returns>
        private static string GetFileContent(string prefix)
        {
            while (true)
            {
                Console.Write(prefix + " ");
                var containerPath = Console.ReadLine();

                try
                {
                    return File.ReadAllText(containerPath);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Wrong path: {e.Message}");
                }
            }
        }


        /// <summary>
        /// Writes content to file
        /// </summary>
        /// <param name="prefix">Prefix to print before path</param>
        /// <param name="content">Content to write</param>
        private static void WriteContentToFile(string prefix, string content)
        {
            while (true)
            {
                Console.Write(prefix + " ");
                var path = Console.ReadLine();

                try
                {
                    File.WriteAllText(path, content);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Wrong path: {e.Message}");
                }
            }
        }

        /// <summary>
        /// Gets positive integer from user
        /// </summary>
        /// <param name="prefix">Prefix to print</param>
        /// <param name="includeZero">Include zero?</param>
        /// <returns>Double from integer</returns>
        private static int GetPositiveIntFromUser(string prefix, bool includeZero)
        {
            while (true)
            {
                Console.Write(prefix + " ");

                if (int.TryParse(Console.ReadLine(), out var number)
                    && number >= 0
                    && (includeZero || number > 0))
                    return number;

                Console.WriteLine($"Please enter integer >{(includeZero ? "=" : string.Empty)} 0");
            }
        }

        /// <summary>
        /// Gets positive double from user
        /// </summary>
        /// <param name="prefix">Prefix to print</param>
        /// <param name="includeZero">Include zero?</param>
        /// <returns>Double from double</returns>
        private static double GetPositiveDoubleFromUser(string prefix, bool includeZero)
        {
            while (true)
            {
                Console.Write(prefix + " ");

                if (double.TryParse(Console.ReadLine(), out var number)
                    && number >= 0
                    && (includeZero || number > 0))
                    return number;

                Console.WriteLine($"Please enter double >{(includeZero ? "=" : string.Empty)} 0");
            }
        }
    }
}