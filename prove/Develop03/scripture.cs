using System.Collections.Generic;

class Scripture
{
    private string _reference;
    private string _text;
    private List<Word> _words;

    public Scripture(string reference, string text)
    {
        _reference = reference;
        _text = text;
        _words = new List<Word>();

        string[] wordArray = text.Split(' ');
        foreach (string wordText in wordArray)
        {
            var word = new Word(wordText);
            _words.Add(word);
        }
    }
}
