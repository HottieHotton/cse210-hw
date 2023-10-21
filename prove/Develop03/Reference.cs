using System;

class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int? _endVerse;

    public Reference(string book, int chapter, int startVerse, int? endVerse = null)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = startVerse;
            _endVerse = endVerse;
        }
    
    public override string ToString() => $"{_book} {_chapter}:{_startVerse}" + (_endVerse.HasValue ? $"-{_endVerse}" : "");
}