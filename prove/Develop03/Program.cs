using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    private string reference;
    private List<Word> words;

    // Constructor
    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    // Method to hide words
    public void HideWords(int count)
    {
        Random random = new Random();
        for (int i = 0; i < count; i++)
        {
            int index = random.Next(0, words.Count);
            words[index].Hide();
        }
    }

    // Method to check if all words are hidden
    public bool AllWordsHidden()
    {
        return words.All(word => word.IsHidden);
    }

    // Method to get the scripture text
    public string GetScriptureText()
    {
        return string.Join(" ", words.Select(word => word.IsHidden ? "_" : word.Text));
    }

    // Getter for reference
    public string GetReference()
    {
        return reference;
    }
}

class Reference
{
    private string reference;

    // Constructor
    public Reference(string reference)
    {
        this.reference = reference;
    }

    // Getter for reference
    public string GetReference()
    {
        return reference;
    }
}

class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }

    // Constructor
    public Word(string text)
    {
        this.Text = text;
        this.IsHidden = false;
    }

    // Method to hide the word
    public void Hide()
    {
        this.IsHidden = true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Test the classes
        Scripture scripture = new Scripture("Helaman 5:12", "And now, my sons, remember, remember that it is upon the rock of our Redeemer, who is Christ, the Son of God, that ye must build your foundation; that when the devil shall send forth his mighty winds, yea, his shafts in the whirlwind, yea, when all his hail and his mighty storm shall beat upon you, it shall have no power over you to drag you down to the gulf of misery and endless wo, because of the rock upon which ye are built, which is a sure foundation, a foundation whereon if men build they cannot fall.");

        Console.WriteLine($"Scripture Reference: {scripture.GetReference()}");
        Console.WriteLine($"Scripture Text: {scripture.GetScriptureText()}");

        while (!scripture.AllWordsHidden())
        {
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideWords(2); // Hide 2 words at a time
            Console.Clear();
            Console.WriteLine($"Scripture Reference: {scripture.GetReference()}");
            Console.WriteLine($"Scripture Text: {scripture.GetScriptureText()}");
        }

        Console.WriteLine("Program ended.");
    }
}
