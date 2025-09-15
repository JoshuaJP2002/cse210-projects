using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] parts = text.Split(" ");
        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    public void HideRandomWords(int count = 3)
    {
        Random rand = new Random();
        for (int i = 0; i < count; i++)
        {
            int index = rand.Next(_words.Count);
            _words[index].Hide();
        }
    }

    public string GetDisplayText()
    {
        string verse = "";
        foreach (Word w in _words)
        {
            verse += w.GetDisplayText() + " ";
        }
        return $"{_reference.GetDisplayText()} {verse.Trim()}";
    }

    public bool AllWordsHidden()
    {
        foreach (Word w in _words)
        {
            if (!w.isHidden())
                return false;
        }
        return true;
    }
}
