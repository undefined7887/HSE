using System;
using System.IO;
using System.Linq;

namespace CommandLib
{
    public class DisksCommand : ICommandExecutable
    {
        public string GetDescription()
        {
            return "Prints available disks";
        }

        public string GetHelp()
        {
            return $"Usage:{Environment.NewLine}" +
                   $"\tdisks{Environment.NewLine}" +
                   $"Description:{Environment.NewLine}" +
                   $"\t{GetDescription()}";
        }

        public void Execute(Context context, Command command)
        {
            DriveInfo[] drives;
            try
            {
                drives = DriveInfo.GetDrives();
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
                Console.WriteLine($"Unknown error occured: {e.Message}");
                return;
            }

            Console.WriteLine($"Disks:" +
                              $"{Environment.NewLine}" +
                              $"{string.Join(Environment.NewLine, drives.Select(x => "\t" + x.Name))}");
        }
    }
}