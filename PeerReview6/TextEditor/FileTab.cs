using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace TextEditor
{
    /// <summary>
    /// Describes single file tab
    /// </summary>
    class FileTab
    {
        public TabPage TabPage { get; }

        private RichTextBox _richTextBox;
        private FastColoredTextBox _fastColoredTextBox;

        public bool IsEdited { get; private set; }
        public bool IsSaved { get; private set; }
        
        public string Name { get; private set; }

        private bool _isLanguage;
        public string SavedPath { get; private set; } = string.Empty;
        private ContextMenuStrip _contextMenuStrip;

        private Theme _theme;

        public Theme Theme
        {
            get => _theme;
            set
            {
                switch (value)
                {
                    case Theme.White:
                        if (_isLanguage)
                        {
                            _fastColoredTextBox.ForeColor = Color.Black;
                            _fastColoredTextBox.BackColor = Color.White;
                        }
                        else
                        {
                            _richTextBox.ForeColor = Color.Black;
                            _richTextBox.BackColor = Color.White;
                        }

                        break;

                    case Theme.Dark:
                        if (_isLanguage)
                        {
                            _fastColoredTextBox.ForeColor = Color.White;
                            _fastColoredTextBox.BackColor = Color.Gray;
                        }
                        else
                        {
                            _richTextBox.ForeColor = Color.White;
                            _richTextBox.BackColor = Color.Gray;
                        }

                        break;
                }
            }
        }

        private FileTab(Theme theme, ContextMenuStrip contextMenuStrip, string path, string text)
        {
            _contextMenuStrip = contextMenuStrip;

            Name = "Untitled";
            var extension = string.Empty;

            if (!path.Equals(string.Empty))
            {
                IsSaved = true;
                SavedPath = path;

                Name = Path.GetFileName(path);
                extension = Path.GetExtension(path);
            }

            TabPage = new TabPage {Text = Name};

            _isLanguage = Extensions.IsLanguage(extension);
            if (_isLanguage)
            {
                var language = Extensions.GetLanguage(extension);
                _fastColoredTextBox = new FastColoredTextBox
                {
                    Dock = DockStyle.Fill,
                    Language = language,
                    Text = text,
                    BorderStyle = BorderStyle.None,
                    ContextMenuStrip = _contextMenuStrip,
                };

                _fastColoredTextBox.TextChanged += TabPage_TextChanged;
                TabPage.Controls.Add(_fastColoredTextBox);
            }
            else
            {
                if (CheckRtf())
                    _richTextBox = new RichTextBox
                    {
                        Dock = DockStyle.Fill,
                        Rtf = text,
                        BorderStyle = BorderStyle.None,
                        ContextMenuStrip = _contextMenuStrip,
                    };
                else
                    _richTextBox = new RichTextBox
                    {
                        Dock = DockStyle.Fill,
                        Text = text,
                        BorderStyle = BorderStyle.None,
                        ContextMenuStrip = _contextMenuStrip,
                    };

                _richTextBox.TextChanged += TabPage_TextChanged;
                TabPage.Controls.Add(_richTextBox);
            }

            Theme = theme;
        }

        public void TabPage_TextChanged(object sender, EventArgs e)
        {
            IsEdited = true;
        }

        /// <summary>
        /// Creates new empty fileTab
        /// </summary>
        /// <param name="theme">App theme</param>
        /// <param name="contextMenuStrip">Context menu action</param>
        /// <returns>FileTab created</returns>
        public static FileTab CreateEmpty(Theme theme, ContextMenuStrip contextMenuStrip)
        {
            return new FileTab(theme, contextMenuStrip, string.Empty, string.Empty);
        }

        /// <summary>
        /// Creates new fileTab and reads data from text
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="theme">App theme</param>
        /// <param name="contextMenuStrip">Context menu action</param>
        /// <returns>FileTab created</returns>
        public static FileTab CreateFromPath(string path, Theme theme, ContextMenuStrip contextMenuStrip)
        {
            try
            {
                return new FileTab(theme, contextMenuStrip, path, File.ReadAllText(path));
            }
            catch (Exception e)
            {
                // ReSharper disable once LocalizableElement
                MessageBox.Show($"Failed to read file: {e.Message}", "Error");
                return null;
            }
        }

        /// <summary>
        /// Creates fileTab from file specified by user
        /// </summary>
        /// <param name="theme">App theme</param>
        /// <param name="contextMenuStrip">Context menu action</param>
        /// <returns>FileTab created</returns>
        public static FileTab CreateFromFile(Theme theme, ContextMenuStrip contextMenuStrip)
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() != DialogResult.OK)
                return null;

            try
            {
                return new FileTab(theme, contextMenuStrip, dialog.FileName, File.ReadAllText(dialog.FileName));
            }
            catch (Exception e)
            {
                // ReSharper disable once LocalizableElement
                MessageBox.Show($"Failed to read file: {e.Message}", "Error");
                return null;
            }
        }

        /// <summary>
        /// Saves fileTab content
        /// </summary>
        public void Save()
        {
            if (IsSaved)
            {
                if (!IsEdited)
                    return;

                try
                {
                    File.WriteAllText(SavedPath,
                        _isLanguage ? _fastColoredTextBox.Text : CheckRtf() ? _richTextBox.Rtf : _richTextBox.Text);
                }
                catch (Exception e)
                {
                    // ReSharper disable once LocalizableElement
                    MessageBox.Show($"Failed to save file: {e.Message}", "Error");
                }
            }
            else SaveAs();
        }

        /// <summary>
        /// Saves As fileTab content
        /// </summary>
        public void SaveAs()
        {
            var dialog = new SaveFileDialog();
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                File.WriteAllText(dialog.FileName,
                    _isLanguage ? _fastColoredTextBox.Text : CheckRtf() ? _richTextBox.Rtf : _richTextBox.Text);

                IsSaved = true;
                Name = Path.GetFileName(dialog.FileName);
                SavedPath = dialog.FileName;

                var extension = Path.GetExtension(dialog.FileName);
                if (!_isLanguage && Extensions.IsLanguage(extension))
                {
                    _isLanguage = true;

                    var text = _richTextBox.Text;
                    var language = Extensions.GetLanguage(extension);

                    TabPage.Controls.Remove(_richTextBox);
                    _richTextBox = null;

                    _fastColoredTextBox = new FastColoredTextBox
                    {
                        Dock = DockStyle.Fill,
                        Language = language,
                        Text = text,
                        BorderStyle = BorderStyle.None,
                        ContextMenuStrip = _contextMenuStrip,
                    };

                    _fastColoredTextBox.TextChanged += TabPage_TextChanged;
                    TabPage.Controls.Add(_fastColoredTextBox);
                }

                TabPage.Text = Path.GetFileName(dialog.FileName);
            }
            catch (Exception e)
            {
                // ReSharper disable once LocalizableElement
                MessageBox.Show($"Failed to save file: {e.Message}", "Error");
            }
        }

        /// <summary>
        /// Undo action
        /// </summary>
        public void Undo()
        {
            if (_isLanguage)
                _fastColoredTextBox.Undo();
            else
                _richTextBox.Undo();
        }

        /// <summary>
        /// Redo action
        /// </summary>
        public void Redo()
        {
            if (_isLanguage)
                _fastColoredTextBox.Redo();
            else
                _richTextBox.Redo();
        }

        /// <summary>
        /// Cut action
        /// </summary>
        public void Cut()
        {
            if (_isLanguage)
                _fastColoredTextBox.Cut();
            else
                _richTextBox.Cut();
        }

        /// <summary>
        /// Copy action
        /// </summary>
        public void Copy()
        {
            if (_isLanguage)
                _fastColoredTextBox.Copy();
            else
                _richTextBox.Copy();
        }

        /// <summary>
        /// Paste action
        /// </summary>
        public void Paste()
        {
            if (_isLanguage)
                _fastColoredTextBox.Paste();
            else
                _richTextBox.Paste();
        }

        /// <summary>
        /// SelectAll action
        /// </summary>
        public void SelectAll()
        {
            if (_isLanguage)
                _fastColoredTextBox.SelectAll();
            else
                _richTextBox.SelectAll();
        }

        /// <summary>
        /// Makes selected text italic
        /// </summary>
        public void MakeItalic()
        {
            if (BlockRtfChanges())
                return;

            _richTextBox.SelectionFont = new Font(
                _richTextBox.SelectionFont,
                FontStyle.Italic ^ _richTextBox.SelectionFont.Style);
        }

        /// <summary>
        /// Makes selected text bold
        /// </summary>
        public void MakeBold()
        {
            if (BlockRtfChanges())
                return;

            _richTextBox.SelectionFont = new Font(
                _richTextBox.SelectionFont,
                FontStyle.Bold ^ _richTextBox.SelectionFont.Style);
        }

        /// <summary>
        /// Makes selected text underline
        /// </summary>
        public void MakeUnderline()
        {
            if (BlockRtfChanges())
                return;

            _richTextBox.SelectionFont = new Font(
                _richTextBox.SelectionFont,
                FontStyle.Underline ^ _richTextBox.SelectionFont.Style);
        }

        /// <summary>
        /// Makes selected text strikeout
        /// </summary>
        public void MakeStrikeout()
        {
            if (BlockRtfChanges())
                return;

            _richTextBox.SelectionFont = new Font(
                _richTextBox.SelectionFont,
                FontStyle.Strikeout ^ _richTextBox.SelectionFont.Style);
        }

        /// <summary>
        /// Makes selected text regular
        /// </summary>
        public void MakeRegular()
        {
            if (BlockRtfChanges())
                return;

            _richTextBox.SelectionFont = new Font(
                _richTextBox.SelectionFont,
                FontStyle.Regular);
        }

        /// <summary>
        /// Checks if current file in RTF Format
        /// </summary>
        public bool CheckRtf()
            => Path.GetExtension(SavedPath).Equals(".rtf");

        /// <summary>
        /// Blocks action if file is not in RTF Format
        /// </summary>
        public bool BlockRtfChanges()
        {
            if (CheckRtf())
                return false;

            MessageBox.Show(
                // ReSharper disable once LocalizableElement
                "This operation can be applied only for .rtf file. Please save or open file with that format.",
                // ReSharper disable once LocalizableElement
                "Error");
            return true;
        }
    }
}