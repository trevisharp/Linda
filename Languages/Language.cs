using System;
using System.IO;

namespace Linda.Languages
{
    public class Language
    {
        private static Language current = null;
        public static Language Current => current;
        public static void Set(Language lang)
        {
            var old = current;
            current = lang;
            if (old != current && Update != null)
                Update();
        }
        public static void AddTranslation(Action<Language> translation)
        {
            Update += () =>
            {
                translation(Current);
            };
            translation(Current);
        }
        public static event Action Update;

        public static Language Portuguese => new Language("langfiles/ptbr.txt");

        public string MainFile { get; set; }

        public Language(string file)
            => this.MainFile = file;
        
        public string Translate(string code)
        {
            StreamReader reader = new StreamReader(this.MainFile);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line.Length > code.Length && line[0] == code[0] && line.Substring(0, code.Length) == code)
                    return line.Split('|')[1];
            }
            return string.Empty;
        }
    }
}