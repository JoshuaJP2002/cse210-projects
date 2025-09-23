using System;
using System.Collections.Generic;

class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthSeconds { get; set; }

    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int lengthSeconds)
    {
        Title = title;
        Author = author;
        LengthSeconds = lengthSeconds;
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthSeconds} seconds");
        Console.WriteLine($"Comments ({GetCommentCount()}):");

        foreach (Comment c in comments)
        {
            Console.WriteLine($"  - {c.Name}: {c.Text}");
        }

        Console.WriteLine(new string('-', 40));
    }
}

class Program
{
    static void Main()
    {
        // Create some videos
        Video video1 = new Video("Learning C#", "Code Academy", 600);
        Video video2 = new Video("Funny Cats Compilation", "PetLovers", 300);
        Video video3 = new Video("Top 10 Travel Destinations", "Travel World", 900);

        // Add comments
        video1.AddComment(new Comment("Alice", "This was super helpful!"));
        video1.AddComment(new Comment("Bob", "Great explanation."));
        video1.AddComment(new Comment("Charlie", "Thanks for sharing."));

        video2.AddComment(new Comment("David", "LOL these cats are hilarious."));
        video2.AddComment(new Comment("Emma", "I love cats so much!"));
        video2.AddComment(new Comment("Frank", "This made my day."));

        video3.AddComment(new Comment("Grace", "I want to visit all these places."));
        video3.AddComment(new Comment("Henry", "Great list, thanks!"));
        video3.AddComment(new Comment("Isabella", "Adding these to my bucket list."));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display each video and its comments
        foreach (Video v in videos)
        {
            v.DisplayVideoInfo();
        }
    }
}
