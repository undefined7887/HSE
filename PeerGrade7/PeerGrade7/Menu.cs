using System;
using System.Collections.Generic;
using System.Linq;

namespace PeerGrade7
{
    /// <summary>
    /// A helpful class to generate beautiful menu in c(k)onsole
    /// </summary>
    public class Menu
    {
        public delegate void OnClick(int index);

        private readonly List<List<string>> _items = new List<List<string>>();
        private readonly List<List<OnClick>> _callbacks = new List<List<OnClick>>();

        private readonly string _header;

        public Menu(string header)
        {
            _header = header;

            _items.Add(new List<string>());
            _callbacks.Add(new List<OnClick>());
        }

        /// <summary>
        /// Appends new menu entry
        /// </summary>
        /// <param name="name">Entry name</param>
        /// <param name="handler">Entry click handler</param>
        public void Append(string name, OnClick handler)
        {
            _items.Last().Add(name);
            _callbacks.Last().Add(handler);
        }

        /// <summary>
        /// Creates new section
        /// </summary>
        public void NewSection()
        {
            _items.Add(new List<string>());
            _callbacks.Add(new List<OnClick>());
        }

        /// <summary>
        /// Runs a menu
        /// </summary>
        public void Run()
        {
            var sectionIndex = 0;
            var elemIndex = 0;

            while (true)
            {
                Console.Clear();
                Console.Write(
                    $"{_header}{Environment.NewLine}{Environment.NewLine}{RenderItems(sectionIndex, elemIndex)}");

                var key = Console.ReadKey();

                // ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        _callbacks[sectionIndex][elemIndex]?.Invoke(elemIndex);
                        return;

                    case ConsoleKey.DownArrow:
                        if (elemIndex != _items[sectionIndex].Count - 1)
                        {
                            elemIndex++;
                            break;
                        }

                        if (sectionIndex == _items.Count - 1)
                            break;

                        sectionIndex++;
                        elemIndex = 0;
                        break;

                    case ConsoleKey.UpArrow:
                        if (elemIndex != 0)
                        {
                            elemIndex--;
                            break;
                        }

                        if (sectionIndex == 0)
                            break;

                        sectionIndex--;
                        elemIndex = _items[sectionIndex].Count - 1;
                        break;
                }
            }
        }

        /// <summary>
        /// Renders a menu state
        /// </summary>
        /// <param name="sectionIndex">Active section</param>
        /// <param name="elemIndex">Active section element</param>
        /// <returns>Rendered string</returns>
        private string RenderItems(int sectionIndex, int elemIndex)
        {
            var content = string.Empty;

            for (var i = 0; i < _items.Count; i++)
            {
                for (var f = 0; f < _items[i].Count; f++)
                    content +=
                        $"{(i == sectionIndex && f == elemIndex ? "> " : "  ")}{_items[i][f]}{Environment.NewLine}";

                content += Environment.NewLine;
            }

            return content;
        }
    }
}