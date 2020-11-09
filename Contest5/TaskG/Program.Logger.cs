using System;
using System.Collections.Generic;
using System.IO;

public partial class Program
{
    public static bool ParseCommandsCount(string input, out int count)
    {
        return int.TryParse(input, out count) && count > 0;
    }

    public class Logger
    {
        private static List<string> logs = new List<string>();
        private static bool mustClear = true;

        private static Logger logger = new Logger();

        public static void HandleCommand(string command)
        {
            if (mustClear)
            {
                File.WriteAllText("logs.log", string.Empty);
                mustClear = false;
            }

            if (command.Equals("WriteAllLogs"))
            {
                if (logs.Count == 0)
                    File.AppendAllText("logs.log", "No active logs" + Environment.NewLine);
                else
                    File.AppendAllLines("logs.log", logs);

                logs.Clear();
            }

            if (command.StartsWith("AddLog"))
                logs.Add(command.Replace("AddLog <", "").Replace(">", ""));

            if (command.StartsWith("DeleteLastLog"))
            {
                if (logs.Count == 0)
                    File.AppendAllText("logs.log", "No active logs" + Environment.NewLine);
                else
                    logs.RemoveAt(logs.Count - 1);
            }
        }
    }
}