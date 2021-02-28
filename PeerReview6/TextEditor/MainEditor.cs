using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace TextEditor
{
    public partial class MainEditor : Form
    {
        private const int Second = 1000;

        private static readonly Random Random = new Random();
        private readonly FileTabManager _fileTabManager;

        private Theme _currentTheme = Theme.White;

        public MainEditor()
        {
            InitializeComponent();

            // Initializing our FileTabManager
            _fileTabManager = new FileTabManager(tabControl);
            LoadSettings();
        }

        /// <summary>
        /// Sets app theme
        /// </summary>
        /// <param name="theme">Theme to set</param>
        private void SetTheme(Theme theme)
        {
            _currentTheme = theme;

            switch (theme)
            {
                case Theme.White:
                    BackColor = Color.WhiteSmoke;

                    menuStrip.ForeColor = Color.Black;
                    menuStrip.BackColor = Color.WhiteSmoke;
                    break;

                case Theme.Dark:
                    BackColor = Color.DimGray;

                    menuStrip.ForeColor = Color.White;
                    menuStrip.BackColor = Color.DimGray;
                    break;
            }

            _fileTabManager.SetTheme(theme);
        }

        /// <summary>
        /// Saves settings
        /// </summary>
        private void SaveSettings()
        {
            var interval = timer.Interval;

            if (!secondToolStripMenuItem.Checked && !fiveSecondsToolStripMenuItem.Checked &&
                !minuteToolStripMenuItem.Checked)
                interval = 0;

            var settings = new Settings()
            {
                SaveInterval = interval,
                CurrentTheme = _currentTheme,
                OpenPaths = _fileTabManager.GetSavedFiles()
            };

            settings.Save();
        }

        /// <summary>
        /// Loads settings
        /// </summary>
        private void LoadSettings()
        {
            var settings = Settings.Read();
            if (settings == null)
                return;

            if (settings.SaveInterval != 0)
            {
                timer.Interval = settings.SaveInterval;
                timer.Start();
            }
            
            if (settings.SaveInterval != 0)
                SetTime(settings.SaveInterval);

            SetTheme(settings.CurrentTheme);

            foreach (var settingsOpenPath in settings.OpenPaths)
                _fileTabManager.Add(FileTab.CreateFromPath(settingsOpenPath, _currentTheme, contextMenuStrip));
        }

        /// <summary>
        /// Sets timer
        /// </summary>
        /// <param name="time">Time interval to set</param>
        private void SetTime(int time)
        {
            switch (time)
            {
                case Second:
                    SecondToolStripMenuItem_Click(null, null);
                    break;
                case Second * 5:
                    FiveSecondsToolStripMenuItem_Click(null, null);
                    break;
                default:
                    MinuteToolStripMenuItem_Click(null, null);
                    break;
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fileTabManager.Add(FileTab.CreateEmpty(_currentTheme, contextMenuStrip));
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fileTabManager.Add(FileTab.CreateFromFile(_currentTheme, contextMenuStrip));
            SaveSettings();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fileTabManager.GetCurrent()?.Save();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fileTabManager.GetCurrent()?.SaveAs();
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fileTabManager.GetCurrent()?.Undo();
        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fileTabManager.GetCurrent()?.Redo();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fileTabManager.GetCurrent()?.Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fileTabManager.GetCurrent()?.Copy();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fileTabManager.GetCurrent()?.Paste();
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fileTabManager.GetCurrent()?.SelectAll();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fileTabManager.CloseCurrent();
            SaveSettings();
        }

        private void SecondToolStripMenuItem_Click(object sender, EventArgs e)
        {
            secondToolStripMenuItem.Checked = !secondToolStripMenuItem.Checked;
            fiveSecondsToolStripMenuItem.Checked = false;
            minuteToolStripMenuItem.Checked = false;

            timer.Stop();

            if (!secondToolStripMenuItem.Checked)
            {
                SaveSettings();
                return;
            }

            timer.Interval = Second;
            timer.Start();
            SaveSettings();
        }

        private void FiveSecondsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            secondToolStripMenuItem.Checked = false;
            fiveSecondsToolStripMenuItem.Checked = !fiveSecondsToolStripMenuItem.Checked;
            minuteToolStripMenuItem.Checked = false;

            timer.Stop();

            if (!fileToolStripMenuItem.Checked)
            {
                SaveSettings();
                return;
            }

            timer.Interval = Second * 5;
            timer.Start();
            SaveSettings();
        }

        private void MinuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            secondToolStripMenuItem.Checked = false;
            fiveSecondsToolStripMenuItem.Checked = false;
            minuteToolStripMenuItem.Checked = !minuteToolStripMenuItem.Checked;

            timer.Stop();

            if (!minuteToolStripMenuItem.Checked)
            {
                SaveSettings();
                return;
            }

            timer.Interval = Second * 60;
            timer.Start();
            SaveSettings();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _fileTabManager.SaveFiles();
        }

        private void WhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTheme(Theme.White);
            SaveSettings();
        }

        private void DarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTheme(Theme.Dark);
            SaveSettings();
        }

        private void ItalicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fileTabManager.GetCurrent()?.MakeItalic();
        }

        private void BoldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fileTabManager.GetCurrent()?.MakeBold();
        }

        private void UnderlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fileTabManager.GetCurrent()?.MakeUnderline();
        }

        private void StrikeoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fileTabManager.GetCurrent()?.MakeStrikeout();
        }

        private void RegularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fileTabManager.GetCurrent()?.MakeRegular();
        }

        private void MainEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            var openedFiles = _fileTabManager.GetUnsavedFiles();

            if (openedFiles.Count == 0)
            {
                e.Cancel = false;
                return;
            }

            var result = MessageBox.Show(
                $"Not all files saved:{Environment.NewLine}{string.Join(Environment.NewLine, openedFiles)}",
                "Confirm exit", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
                return;

            e.Cancel = true;
        }

        private void SaveAllFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fileTabManager.SaveFiles();
        }
    }
}