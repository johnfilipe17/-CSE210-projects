using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        List<Scripture> scriptures = LoadScripturesFromJson("scriptures.json");
        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found.");
            return;
        }

        var random = new Random();
        var selectedScripture = scriptures[random.Next(scriptures.Count)];
        var memorizer = new ScriptureMemorizer(selectedScripture);

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

    static List<Scripture> LoadScripturesFromJson(string filename)
    {
        string json = File.ReadAllText(filename);
        return JsonConvert.DeserializeObject<List<Scripture>>(json);
    }
}

class Scripture
{
    public string Reference { get; set; }
    public string Text { get; set; }
    public List<Word> Words { get; set; }

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
