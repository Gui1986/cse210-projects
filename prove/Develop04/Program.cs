using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PerformBreathingActivity();
                    break;
                case "2":
                    PerformReflectionActivity();
                    break;
                case "3":
                    PerformListingActivity();
                    break;
                case "4":
                    Console.WriteLine("Exiting the program...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void PerformBreathingActivity()
    {
        Console.Write("Enter duration for Breathing Activity (in seconds): ");
        int duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Welcome to the Breathing Activity: This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        StartPause();
        PerformCountdown(duration);
        Console.WriteLine("Breathing activity ended.");
    }

    static void PerformReflectionActivity()
    {
        Console.Write("Enter duration for Reflection Activity (in seconds): ");
        int duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Welcome to the Reflection Activity: This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        StartPause();
        PerformCountdown(duration);
        Console.WriteLine("Reflection activity ended.");
    }

    static void PerformListingActivity()
    {
        Console.Write("Enter duration for Listing Activity (in seconds): ");
        int duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Welcome to the Listing Activity: This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        StartPause();
        PerformCountdown(duration);
        Console.WriteLine("Listing activity ended.");
    }

    static void StartPause()
    {
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    static void PerformCountdown(int duration)
    {
        for (int i = duration; i > 0; i--)
        {
            Console.WriteLine($"Time remaining: {i} seconds");
            Thread.Sleep(1000); // Pause for 1 second
        }
    }
}
