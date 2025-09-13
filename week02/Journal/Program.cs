using System;
using System.Text;

namespace JournalApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Prepare prompts (add your own)
            var prompts = new[]
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?"
            };

            var promptGenerator = new PromptGenerator(prompts);
            var journal = new Journal();

            while (true)
            {
                Console.WriteLine("\nCSE Journal App");
                Console.WriteLine("1) Write a new entry");
                Console.WriteLine("2) Display the journal");
                Console.WriteLine("3) Save the journal to a file");
                Console.WriteLine("4) Load the journal from a file");
                Console.WriteLine("5) Clear current entries");
                Console.WriteLine("6) Quit");
                Console.Write("Choose an option (1-6): ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        WriteNewEntry(promptGenerator, journal);
                        break;
                    case "2":
                        DisplayJournal(journal);
                        break;
                    case "3":
                        SaveJournal(journal);
                        break;
                    case "4":
                        LoadJournal(journal);
                        break;
                    case "5":
                        journal.Clear();
                        Console.WriteLine("All current entries cleared (in memory).");
                        break;
                    case "6":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Enter 1-6.");
                        break;
                }
            }
        }

        private static void WriteNewEntry(PromptGenerator pg, Journal journal)
        {
            var prompt = pg.GetRandomPrompt();
            Console.WriteLine($"\nPrompt: {prompt}");
            Console.WriteLine("Enter your response. Press an empty line by itself when finished:");
            var sb = new StringBuilder();
            while (true)
            {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) break;
                sb.AppendLine(line);
            }

            var response = sb.ToString().TrimEnd('\r', '\n');
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            var entry = new Entry(date, prompt, response);
            journal.AddEntry(entry);
            Console.WriteLine("Entry saved to the journal (memory).");
        }

        private static void DisplayJournal(Journal journal)
        {
            var entries = journal.GetEntries();
            if (entries.Count == 0)
            {
                Console.WriteLine("\nThe journal is empty.");
                return;
            }

            Console.WriteLine($"\nJournal contains {entries.Count} entries:");
            var i = 1;
            foreach (var e in entries)
            {
                Console.WriteLine($"\n--- Entry {i++} ---");
                Console.WriteLine(e.ToString());
            }
        }

        private static void SaveJournal(Journal journal)
        {
            Console.Write("Enter filename to save (e.g. myjournal.txt): ");
            var filename = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(filename))
            {
                Console.WriteLine("Invalid filename - save cancelled.");
                return;
            }

            try
            {
                journal.Save(filename);
                Console.WriteLine($"Journal saved to '{filename}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
        }

        private static void LoadJournal(Journal journal)
        {
            Console.Write("Enter filename to load (e.g. myjournal.txt): ");
            var filename = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(filename))
            {
                Console.WriteLine("Invalid filename - load cancelled.");
                return;
            }

            try
            {
                var ok = journal.Load(filename);
                if (ok)
                    Console.WriteLine($"Journal loaded from '{filename}'. (Current in-memory entries replaced.)");
                else
                    Console.WriteLine($"File '{filename}' not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
            }
        }
    }
}
