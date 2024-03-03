using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompting the user for their first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Prompting the user for their last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Displaying the user's name in the specified format using string interpolation
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}
