using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JournalApp
{
    public class Journal
    {
        private List<Entry> _entries = new List<Entry>();

        public void AddEntry(Entry entry)
        {
            _entries.Add(entry);
        }

        public IReadOnlyList<Entry> GetEntries()
        {
            return _entries.AsReadOnly();
        }

        public void Clear()
        {
            _entries.Clear();
        }

        public void Save(string filename)
        {
            using (var sw = new StreamWriter(filename, false))
            {
                foreach (var e in _entries)
                {
                    sw.WriteLine(e.ToFileString());
                }
            }
        }

        public bool Load(string filename)
        {
            if (!File.Exists(filename)) return false;
            var lines = File.ReadAllLines(filename);
            var list = new List<Entry>();
            foreach (var l in lines)
            {
                var e = Entry.FromFileString(l);
                if (e != null) list.Add(e);
            }
            _entries = list;
            return true;
        }
    }
}
