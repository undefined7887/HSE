using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    /// <summary>
    /// Describes text editor themes
    /// </summary>
    class Settings
    {
        /// <summary>
        /// Autosave
        /// </summary>
        public int SaveInterval { get; set; }
        
        /// <summary>
        /// App theme
        /// </summary>
        public Theme CurrentTheme { get; set; }

        /// <summary>
        /// Opened editors
        /// </summary>
        public List<string> OpenPaths { get; set; }

        /// <summary>
        /// Saves settings to file
        /// </summary>
        public void Save()
        {
            var content = SaveInterval + " " + (CurrentTheme == Theme.White ? "1" : "2") + Environment.NewLine;

            foreach (var openPath in OpenPaths)
                content += openPath + Environment.NewLine;

            try
            {
                File.WriteAllText("settings.txt", content);
            }
            catch (Exception e)
            {

            }
            
        }

        /// <summary>
        /// Reads settings from file
        /// </summary>
        /// <returns>Settings class instance</returns>
        public static Settings Read()
        {
            var content = string.Empty;
            try
            {
                content = File.ReadAllText("settings.txt");
            }
            catch (Exception e)
            {
                return null;
            }

            var lines = content.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var splitFirstLine = lines[0].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if (splitFirstLine.Length != 2)
                return null;

            if (!int.TryParse(splitFirstLine[0], out var saveInterval))
                return null;

            var theme = (splitFirstLine[1] == "1") ? Theme.White : Theme.Dark;
            var filePaths = new List<string>();

            for (var i = 1; i < lines.Length; i++)
                filePaths.Add(lines[i]);

            return new Settings()
            {
                SaveInterval = saveInterval,
                CurrentTheme = theme,
                OpenPaths = filePaths
            };
        }
    }
}
