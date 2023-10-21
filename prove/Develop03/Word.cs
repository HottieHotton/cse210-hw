using System;

class Word
{
    private string _text;
    public bool _isHidden;

    public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

    public void Hide()
        {
            _isHidden = true;
        }

    public override string ToString() => _isHidden ? "_____" : _text;
        
}