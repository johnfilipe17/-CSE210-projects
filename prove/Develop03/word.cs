class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Display()
    {
        if (_isHidden)
            Console.Write(" [hidden]");
        else
            Console.Write($" {_text}");
    }
}
