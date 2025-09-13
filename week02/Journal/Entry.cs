using System;

namespace JournalApp
{
    public class Entry
    {
        public string Date { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }

        public Entry(string date, string prompt, string response)
        {
            Date = date;
            Prompt = prompt;
            Response = response;
        }

        // For display to the user
        public override string ToString()
        {
            return $"{Date}\nPrompt: {Prompt}\nResponse: {Response}";
        }

        // Line format for saving: Date~|~Prompt~|~Response
        public string ToFileString()
        {
            return $"{Escape(Date)}~|~{Escape(Prompt)}~|~{Escape(Response)}";
        }

        private static string Escape(string s)
        {
            if (s == null) return "";
            // preserve newlines, escape the delimiter by replacing occurrences
            return s.Replace("\r", "\\r").Replace("\n", "\\n").Replace("~|~", " ");
        }

        private static string Unescape(string s)
        {
            if (s == null) return "";
            return s.Replace("\\r", "\r").Replace("\\n", "\n");
        }

        public static Entry FromFileString(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return null;
            var parts = line.Split(new[] { "~|~" }, StringSplitOptions.None);
            if (parts.Length < 3) return null;
            var date = Unescape(parts[0]);
            var prompt = Unescape(parts[1]);
            // If the response contains additional "~|~" pieces, join the rest
            var response = string.Join("~|~", parts, 2, parts.Length - 2);
            response = Unescape(response);
            return new Entry(date, prompt, response);
        }
    }
}
