using System;

namespace CommandLib
{
    public class ClearCommand : ICommandExecutable
    {
        public string GetDescription()
        {
            return "Clears terminal screen";
        }

        public string GetHelp()
        {
            return $"Usage:{Environment.NewLine}" +
                   $"\tclear{Environment.NewLine}" +
                   $"Description:{Environment.NewLine}" +
                   $"\t{GetDescription()}";
        }

        public void Execute(Context context, Command command)
        {
            Console.Clear();
        }
    }
}