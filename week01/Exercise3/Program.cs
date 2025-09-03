using System;

class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        int magic = rand.Next(1, 101);

        int guess = -1;
        while (guess != magic)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess < magic)
                Console.WriteLine("Higher");
            else if (guess > magic)
                Console.WriteLine("Lower");
            else
                Console.WriteLine("You guessed it!");
        }
    }
}