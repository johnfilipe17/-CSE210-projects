using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
       var scripture = new Scripture("Mosiah 3:19", "For the natural man is an enemy to God, and has been from the fall of Adam, and will be, forever and ever, unless he yields to the enticings of the Holy Spirit, and putteth off the natural man and becometh a saint through the atonement of Christ the Lord, and becometh as a child, submissive, meek, humble, patient, full of love, willing to submit to all things which the Lord seeth fit to inflict upon him, even as a child doth submit to his father.");
        var memorizer = new ScriptureMemorizer(scripture);

        while (true)
        {
            Console.Clear();
            memorizer.DisplayScripture();

            Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            memorizer.HideRandomWord();
        }
    }
}

class Scripture
{
    public string Reference { get; }
    public string Text { get; }
    public List<Word> Words { get; }

    public Scripture(string reference, string text)
    {
        Reference = reference;
        Text = text;
        Words = new List<Word>();

        string[] wordArray = text.Split(' ');
        foreach (string wordText in wordArray)
        {
            var word = new Word(wordText);
            Words.Add(word);
        }
    }
}

class Reference
{
    public string Text { get; }

    public Reference(string text)
    {
        Text = text;
    }
}

class Word
{
    public string Text { get; }
    public bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }
}

class ScriptureMemorizer
{
    private readonly Scripture _scripture;
    private readonly Random _random;

    public ScriptureMemorizer(Scripture scripture)
    {
        _scripture = scripture;
        _random = new Random();
    }

    public void DisplayScripture()
    {
        Console.WriteLine($"{_scripture.Reference}:");
        foreach (Word word in _scripture.Words)
        {
            if (word.IsHidden)
                Console.Write(" [hidden]");
            else
                Console.Write($" {word.Text}");
        }
        Console.WriteLine();
    }

    public void HideRandomWord()
    {
        List<Word> visibleWords = GetVisibleWords();
        if (visibleWords.Count == 0)
            return;

        int randomIndex = _random.Next(visibleWords.Count);
        visibleWords[randomIndex].IsHidden = true;
    }

    private List<Word> GetVisibleWords()
    {
        var visibleWords = new List<Word>();
        foreach (Word word in _scripture.Words)
        {
            if (!word.IsHidden)
                visibleWords.Add(word);
        }
        return visibleWords;
    }
}
