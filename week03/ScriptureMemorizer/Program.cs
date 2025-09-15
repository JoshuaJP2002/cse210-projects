using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his only begotten Son, " +
            "that whosoever believeth in him should not perish, but have everlasting life.");

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress ENTER to hide words or type 'quit' to end.");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            if (scripture.AllWordsHidden())
                break;

            scripture.HideRandomWords();
        }

        Console.WriteLine("\nAll words are hidden. Program ended.");
    }
}