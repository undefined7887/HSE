using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    /// <summary>
    /// Manages file tabs
    /// </summary>
    class FileTabManager
    {
        private readonly TabControl _tabControl;
        private readonly Dictionary<TabPage, FileTab> _fileTabs = new Dictionary<TabPage, FileTab>();

        public FileTabManager(TabControl tabControl)
        {
            _tabControl = tabControl;
        }

        /// <summary>
        /// Adds new file tab
        /// </summary>
        /// <param name="fileTab">FileTab to add</param>
        public void Add(FileTab fileTab)
        {
            if (fileTab == null)
                return;

            _tabControl.TabPages.Add(fileTab.TabPage);
            _tabControl.SelectedTab = fileTab.TabPage;

            _fileTabs.Add(fileTab.TabPage, fileTab);
        }

        /// <summary>
        /// Returns selected FileTab
        /// </summary>
        /// <returns>Selected FileTab</returns>
        public FileTab GetCurrent()
            => _tabControl.SelectedTab == null ? null : _fileTabs[_tabControl.SelectedTab];

        /// <summary>
        /// Closes active FileTab
        /// </summary>
        public void CloseCurrent()
        {
            var tabPage = _tabControl.SelectedTab;
            _fileTabs.Remove(tabPage);

            var index = _tabControl.TabPages.IndexOf(tabPage);
            _tabControl.TabPages.RemoveAt(index);

            if (_tabControl.TabPages.Count != 0)
                _tabControl.SelectedTab = _tabControl.TabPages[Math.Max(index - 1, 0)];
        }

        /// <summary>
        /// 
        /// </summary>
        public void SaveFiles()
        {
            foreach (var entry in _fileTabs.Where(entry => entry.Value.IsSaved))
                entry.Value.Save();
        }

        public void SetTheme(Theme theme)
        {
            foreach (var entry in _fileTabs)
                entry.Value.Theme = theme;
        }

        public List<string> GetSavedFiles()
        {
            return (from fileTab in _fileTabs where fileTab.Value.IsSaved select fileTab.Value.SavedPath).ToList();
        }

        public List<string> GetUnsavedFiles()
        {
            return (from fileTab in _fileTabs where fileTab.Value.IsEdited select fileTab.Value.Name).ToList();
        }
    }
}
