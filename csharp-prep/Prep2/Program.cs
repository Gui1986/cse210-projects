using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        int gradePercentage = Convert.ToInt32(Console.ReadLine());

        // Determine the letter grade
        char letter;

        if (gradePercentage >= 90)
        {
            letter = 'A';
        }
        else if (gradePercentage >= 80)
        {
            letter = 'B';
        }
        else if (gradePercentage >= 70)
        {
            letter = 'C';
        }
        else if (gradePercentage >= 60)
        {
            letter = 'D';
        }
        else
        {
            letter = 'F';
        }

        // Check if the user passed the course
        if (gradePercentage >= 70)
        {
            Console.WriteLine($"Congratulations! You passed the course with a grade of {letter}.");
        }
        else
        {
            Console.WriteLine($"You did not pass the course this time. Better luck next time!");
        }

        // Print the letter grade
        Console.WriteLine($"Your letter grade is {letter}.");
    }
}
