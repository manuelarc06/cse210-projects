// Creativity: I added a progress counter that displays how many words are still visible out of the total words in the scripture to help with memorization.

using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("John", 3, 16);
        string text = "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            int totalWords = scripture.GetTotalWords();
            int hiddenWords = scripture.GetHiddenWordsCount();
            int visibleWords = totalWords - hiddenWords;

            Console.WriteLine($"\nWords remaining: {visibleWords} / {totalWords}");
            Console.WriteLine("\nTap ENTER so you can hide the words or write (quit) to quit the program: ");

            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nWords remaining: 0 / " + totalWords);
                Console.WriteLine("\nAll words have been hidden.");
                break;
            }
        }

    }
}
