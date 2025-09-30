using System;

namespace Homework
{
    public class WritingAssignment : Assignment
    {
        private string _title;

        // Constructor
        public WritingAssignment(string studentName, string topic, string title)
            : base(studentName, topic)
        {
            _title = title;
        }

        public string GetWritingInformation()
        {
            return $"{_title} by {_studentName}";
        }
    }
}