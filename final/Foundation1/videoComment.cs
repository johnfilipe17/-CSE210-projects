using System;
using System.Collections.Generic;

interface IComment
{
    string GetName();
    string GetText();
}

class Comment : IComment
{
    public string Name { get; }
    public string Text { get; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }

    public string GetName()
    {
        return Name;
    }

    public string GetText()
    {
        return Text;
    }
}

interface IVideo
{
    string GetTitle();
    string GetAuthor();
    int GetLength();
    void AddComment(string name, string text);
    int GetNumComments();
    void DisplayComments();
}

class Video : IVideo
{
    public string Title { get; }
    public string Author { get; }
    public int Length { get; }
    private List<IComment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<IComment>();
    }

    public void AddComment(string name, string text)
    {
        IComment comment = new Comment(name, text);
        comments.Add(comment);
    }

    public int GetNumComments()
    {
        return comments.Count;
    }

    public void DisplayComments()
    {
        foreach (IComment comment in comments)
        {
            Console.WriteLine(comment.GetName() + ": " + comment.GetText());
        }
    }

    public string GetTitle()
    {
        return Title;
    }

    public string GetAuthor()
    {
        return Author;
    }

    public int GetLength()
    {
        return Length;
    }
}

class Program
{
    static void Main()
    {
        // Create videos
        IVideo video1 = new Video("Ronaldo best skills Compilation", "Best skills", 180);
        video1.AddComment("soccerLover123", "These moves are insane!");
        video1.AddComment("RonalFanatic", "I can't stop watching this!");

        IVideo video2 = new Video("Cooking Tutorial: Chocolate Cake", "ChefGordon", 300);
        video2.AddComment("FoodieForever", "The cake looks delicious!");
        video2.AddComment("BakingQueen", "I'll try this recipe ASAP!");

        IVideo video3 = new Video("Before I forget Guitar Cover", "RockstarMusic", 420);
        video3.AddComment("MusicLover22", "Great tutorial!");
        video3.AddComment("GuitarFan101", "Thanks for sharing the chords!");

        // Store videos in a list
        List<IVideo> videos = new List<IVideo> { video1, video2, video3 };

        // Display video information and comments
        foreach (IVideo video in videos)
        {
            Console.WriteLine("Title: " + video.GetTitle());
            Console.WriteLine("Author: " + video.GetAuthor());
            Console.WriteLine("Length: " + video.GetLength() + " seconds");
            Console.WriteLine("Number of Comments: " + video.GetNumComments());
            Console.WriteLine("Comments:");
            video.DisplayComments();
            Console.WriteLine();
        }
    }
}