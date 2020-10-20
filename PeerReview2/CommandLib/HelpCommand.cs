using System;
using System.Linq;

namespace CommandLib
{
    public class HelpCommand : ICommandExecutable
    {
        public string GetDescription()
        {
            return "Prints detailed information about application";
        }

        public string GetHelp()
        {
            return $"Usage:{Environment.NewLine}" +
                   $"\thelp [command]{Environment.NewLine}" +
                   $"Description:{Environment.NewLine}" +
                   $"\t{GetDescription()}";
        }

        public void Execute(Context context, Command command)
        {
            if (command.Arguments.Count == 0)
                PrintDefaultHelp(context);
            else if (context.Commands.ContainsKey(command.Arguments[0]))
                Console.WriteLine(context.Commands[command.Arguments[0]].GetHelp());
            else
                Console.WriteLine("Command not found");
        }

        private static void PrintDefaultHelp(Context context)
        {
            var content = $"Usage:{Environment.NewLine}" +
                          $"\tcommand [arguments]... <flags>...{Environment.NewLine}" +
                          $"{Environment.NewLine}" +
                          $"Possible commands:{Environment.NewLine}";

            var maxCommandNameLength = context.Commands
                .Select(x => x.Key)
                .Select(x => x.Length)
                .Max();

            foreach (var (key, value) in context.Commands)
            {
                content += "\t" + key;

                for (var i = 0; i < maxCommandNameLength - key.Length + 5; i++)
                    content += " ";

                content += value.GetDescription() + Environment.NewLine;
            }

            content += $"{Environment.NewLine}" +
                       $"You can also see detailed information about each command:{Environment.NewLine}" +
                       $"\thelp [command]";

            Console.WriteLine(content);
        }
    }
}