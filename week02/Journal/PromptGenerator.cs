using System;
using System.Collections.Generic;
using System.Linq;

namespace JournalApp
{
    public class PromptGenerator
    {
        private readonly List<string> _prompts;
        private readonly Random _rand = new Random();

        public PromptGenerator(IEnumerable<string> prompts)
        {
            _prompts = prompts.ToList();
        }

        public string GetRandomPrompt()
        {
            if (_prompts.Count == 0) return string.Empty;
            return _prompts[_rand.Next(_prompts.Count)];
        }
    }
}
