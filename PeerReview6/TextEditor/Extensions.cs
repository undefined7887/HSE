using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastColoredTextBoxNS;

namespace TextEditor
{
    struct Extensions
    {
        private static readonly Dictionary<string, Language> _dictionary = new Dictionary<string, Language>();

        static Extensions()
        {
            _dictionary.Add(".cs", Language.CSharp);
            _dictionary.Add(".html", Language.HTML);
            _dictionary.Add(".js", Language.JS);
            _dictionary.Add(".lua", Language.Lua);
            _dictionary.Add(".sql", Language.SQL);
            _dictionary.Add(".xml", Language.XML);
        }

        public static bool IsLanguage(string extension)
            => _dictionary.ContainsKey(extension);

        public static Language GetLanguage(string extension)
            => _dictionary[extension];
    }
}
