using System;

class Scripture
{
    private Reference _Reference;
    private List<Word> _Words;

    public Scripture(Reference reference, string text)
        {
            _Reference = reference;
            _Words = text.Split(' ').Select(w => new Word(w)).ToList();
        }
    public void HideRandomWords()
        {
            Random rand = new Random();
            var wordToHide = _Words[rand.Next(_Words.Count)];
            if(wordToHide._isHidden != true){
                wordToHide.Hide();
            }else{
            HideRandomWords();
            }
        }

        public bool AllWordsHidden => _Words.All(w => w._isHidden);

        public override string ToString() => $"{_Reference} - " + string.Join(" ", _Words);
}