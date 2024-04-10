using System;
using System.Collections.Generic;

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(string commenter, string text)
    {
        Comments.Add(new Comment(commenter, text));
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"- {comment.Commenter}: {comment.Text}");
        }
    }
}

class Comment
{
    public string Commenter { get; set; }
    public string Text { get; set; }

    public Comment(string commenter, string text)
    {
        Commenter = commenter;
        Text = text;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a sample video
        Video video = new Video("Introduction to Abstraction", "John Doe", 300);

        // Add comments to the video
        video.AddComment("Alice", "Great video!");
        video.AddComment("Bob", "I learned a lot from this.");

        // Display video details
        video.DisplayDetails();
    }
}
