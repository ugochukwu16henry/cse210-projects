using System;

namespace Homework
{
    public class Assignment
    {
        // Protected member variables so derived classes can access them
        protected string _studentName;
        protected string _topic;

        // Constructor
        public Assignment(string studentName, string topic)
        {
            _studentName = studentName;
            _topic = topic;
        }

        // Method to get summary
        public string GetSummary()
        {
            return $"{_studentName} - {_topic}";
        }
    }
}