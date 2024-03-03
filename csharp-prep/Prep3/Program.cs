using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        bool playAgain = true;

        while (playAgain)
        {
            int magicNumber = random.Next(1, 101); // Generate a random number between 1 and 100
            int guess;
            int attempts = 0;
            bool guessedCorrectly = false;

            Console.WriteLine("I've picked a magic number between 1 and 100. Try to guess it!");

            while (!guessedCorrectly)
            {
                Console.Write("What is your guess? ");
                guess = Convert.ToInt32(Console.ReadLine());
                attempts++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    guessedCorrectly = true;
                }
            }

            Console.WriteLine($"It took you {attempts} attempts to guess the magic number.");

            Console.Write("Do you want to play again? (yes/no): ");
            string playAgainResponse = Console.ReadLine().ToLower();
            playAgain = (playAgainResponse == "yes");
        }
    }
}
