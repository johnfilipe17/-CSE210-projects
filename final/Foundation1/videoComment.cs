using System;
using System.Collections.Generic;

interface IComment
{
    string GetName();
    string GetText();
}

class Comment : IComment
{
    private string _name;
    private string _text;

    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetText()
    {
        return _text;
    }
}

interface IVideo
{
    string Title { get; }
    string Author { get; }
    int Length { get; }
    void AddComment(string name, string text);
    int GetNumComments();
    IEnumerable<IComment> GetComments();
}

class Video : IVideo
{
    private List<IComment> _comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        _comments = new List<IComment>();
    }

    public string Title { get; }
    public string Author { get; }
    public int Length { get; }

    public void AddComment(string name, string text)
    {
        IComment comment = new Comment(name, text);
        _comments.Add(comment);
    }

    public int GetNumComments()
    {
        return _comments.Count;
    }

    public IEnumerable<IComment> GetComments()
    {
        return _comments;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        IVideo video1 = new Video("Funny Cats Compilation", "CrazyCatLady", 180);
        video1.AddComment("CatLover123", "These cats are hilarious!");
        video1.AddComment("KittenFanatic", "I can't stop watching this!");

        IVideo video2 = new Video("Cooking Tutorial: Chocolate Cake", "ChefGordon", 300);
        video2.AddComment("FoodieForever", "The cake looks delicious!");
        video2.AddComment("BakingQueen", "Can't wait to try this recipe!");

        IVideo video3 = new Video("Guitar Lesson: Beginner's Guide", "RockstarMusic", 420);
        video3.AddComment("MusicLover22", "Great tutorial for beginners!");
        video3.AddComment("GuitarFan101", "Thanks for sharing the chords!");

        // Store videos in a list
        List<IVideo> videos = new List<IVideo> { video1, video2, video3 };

        // Display video information and comments
        foreach (IVideo video in videos)
        {
            Console.WriteLine("Title: " + video.Title);
            Console.WriteLine("Author: " + video.Author);
            Console.WriteLine("Length: " + video.Length + " seconds");
            Console.WriteLine("Number of Comments: " + video.GetNumComments());
            Console.WriteLine("Comments:");
            foreach (IComment comment in video.GetComments())
            {
                Console.WriteLine(comment.GetName() + ": " + comment.GetText());
            }
            Console.WriteLine();
        }
    }
}
