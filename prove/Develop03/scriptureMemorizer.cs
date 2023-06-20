using System;
using System.Collections.Generic;

class ScriptureMemorizer
{
    private readonly Scripture _scripture;
    private readonly Reference _reference;
    private readonly Random _random;

    public ScriptureMemorizer(Scripture scripture, Reference reference)
    {
        _scripture = scripture;
        _reference = reference;
        _random = new Random();
    }

    public void DisplayScripture()
    {
        _reference.DisplayReference();

        foreach (Word word in _scripture._words)
        {
            word.Display();
        }

        Console.WriteLine();
    }

    public void HideRandomWord()
    {
        List<Word> visibleWords = GetVisibleWords();
        if (visibleWords.Count == 0)
            return;

        int randomIndex = _random.Next(visibleWords.Count);
        visibleWords[randomIndex].Hide();
    }

    private List<Word> GetVisibleWords()
    {
        var visibleWords = new List<Word>();
        foreach (Word word in _scripture._words)
        {
            if (!word._isHidden)
                visibleWords.Add(word);
        }
        return visibleWords;
    }
}
