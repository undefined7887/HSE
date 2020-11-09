using System;
using System.Collections.Generic;

namespace CommandLib
{
    public class Command
    {
        private Command()
        {
        }

        /// <summary>
        /// Command name, for example: 'ls', 'cd', etc...
        /// </summary>
        public string Name { get; private set; } = string.Empty;

        /// <summary>
        /// Main command argument.
        /// </summary>
        public List<string> Arguments { get; } = new List<string>();

        /// <summary>
        /// Command flags, for example: '-utf8', '-utf16', etc...
        /// </summary>
        public List<string> Flags { get; } = new List<string>();

        /// <summary>
        /// Parses line into comfortable Command class
        /// </summary>
        /// <param name="line">Line to parse</param>
        /// <returns>Request class instance</returns>
        public static Command Parse(string line)
        {
            var splitLine = line.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            switch (splitLine.Length)
            {
                case 0:
                    return new Command();
                case 1:
                    return new Command {Name = splitLine[0]};
                default:
                {
                    var command = new Command {Name = splitLine[0]};

                    var argsAndFlags = splitLine[1]
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    bool args = true, canSwitchToFlags = false;
                    var argsList = new List<string>();

                    for (var i = 0; i < argsAndFlags.Length; i++)
                    {
                        if (i != 0 && canSwitchToFlags && argsAndFlags[i].StartsWith('-'))
                        {
                            args = false;
                            command.Flags.Add(argsAndFlags[i]);
                        }

                        if (!args)
                            continue;

                        argsList.Add(argsAndFlags[i]);
                        canSwitchToFlags = !argsAndFlags[i].EndsWith('\\');
                    }

                    var index = 0;
                    for (var i = 0; i < argsList.Count; i++)
                    {
                        command.Arguments.Add(string.Empty);
                        while (argsList[i].EndsWith('\\'))
                        {
                            command.Arguments[index] += argsList[i][..^1] + " ";
                            i++;
                        }

                        command.Arguments[index] += argsList[i];
                        index++;
                    }

                    return command;
                }
            }
        }
    }
}