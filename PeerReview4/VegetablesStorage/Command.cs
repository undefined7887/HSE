using System;

namespace VegetablesStorage
{
    /// <summary>
    /// Represents command from file
    /// </summary>
    public class Command
    {
        
        /// <summary>
        /// Command name
        /// </summary>
        public string Name { get; private set; }
        
        /// <summary>
        /// Command parameter
        /// </summary>
        public int Parameter { get; private set; }

        /// <summary>
        /// Parses command from line
        /// </summary>
        /// <param name="line">Line to parse</param>
        /// <returns>Parsed command</returns>
        public static Command Parse(string line)
        {
            var splitLine = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (splitLine.Length != 2)
                return null;

            if (splitLine[0] != "add" && splitLine[0] != "remove")
                return null;
            
            if (!int.TryParse(splitLine[1], out var index) || index < 0)
                return null;

            return new Command {Name = splitLine[0], Parameter = index};
        }
    }
}