using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();
    
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] splitWords = text.Split(" ");
        foreach (string w in splitWords)
        {
            _words.Add(new Word(w));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        int visibleWords = 0;
        foreach (Word word in _words)
        {
            if (!word.IsHidden()) visibleWords++;
        }

        int wordsToHide = Math.Min(numberToHide, visibleWords);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = _random.Next(_words.Count);

            while (_words[index].IsHidden())
            {
                index = _random.Next(_words.Count);
            }

            _words[index].Hide();
        }
    }

    public string GetDisplayText()
    {
        string referenceText = _reference.GetDisplayText();
        List<string> displayedWords = new List<string>();

        foreach (Word word in _words)
        {
            displayedWords.Add(word.GetDisplayText());
        }

        string scriptureText = string.Join(" ", displayedWords);
        return $"{referenceText}\n{scriptureText}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

    public int GetTotalWords()
    {
        return _words.Count;
    }

    public int GetHiddenWordsCount()
    {
        int count = 0;
        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                count++;
            }
        }
        return count;
    }
}