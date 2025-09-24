using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }

    public override string ToString()
    {
        return $"{CommenterName}: {CommentText}";
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> _comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");

        foreach (Comment c in _comments)
        {
            Console.WriteLine($" - {c}");
        }

        Console.WriteLine(new string('-', 40));
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(" This is the OnlineOrdering Project.\n");

        // Create videos
        List<Video> videos = new List<Video>();

        Video video1 = new Video("C# Basics Tutorial", "Code Academy", 600);
        video1.AddComment(new Comment("Alice", "Very helpful tutorial!"));
        video1.AddComment(new Comment("Bob", "I finally understand classes."));
        video1.AddComment(new Comment("Charlie", "Could you explain inheritance next?"));

        Video video2 = new Video("Cooking Pasta", "Chef Mario", 420);
        video2.AddComment(new Comment("Diana", "This made me so hungry!"));
        video2.AddComment(new Comment("Ethan", "Simple and delicious."));
        video2.AddComment(new Comment("Fiona", "I tried this and it worked perfectly!"));

        Video video3 = new Video("Travel Vlog: Paris", "Nomad Life", 900);
        video3.AddComment(new Comment("George", "I want to visit Paris now."));
        video3.AddComment(new Comment("Hannah", "Beautiful video, thank you for sharing."));
        video3.AddComment(new Comment("Ian", "The Eiffel Tower looks amazing at night."));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display video info with comments
        foreach (Video v in videos)
        {
            v.DisplayVideoInfo();
        }
    }
}
