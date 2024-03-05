using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    // Class representing a journal entry
    class JournalEntry
    {
        public string Prompt { get; set; }
        public string Response { get; set; }
        public string Date { get; set; }

        // Constructor
        public JournalEntry(string prompt, string response, string date)
        {
            Prompt = prompt;
            Response = response;
            Date = date;
        }

        // Override ToString() method to display entry details
        public override string ToString()
        {
            return $"{Date}: {Prompt}\n{Response}\n";
        }
    }

    // Class representing the Journal app
    class Journal
    {
        private List<JournalEntry> entries = new List<JournalEntry>();

        // Method to write a new entry
        public void WriteNewEntry()
        {
            string[] prompts = {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?"
            };

            // Select a random prompt
            Random random = new Random();
            int index = random.Next(prompts.Length);
            string prompt = prompts[index];

            // Get user response
            Console.WriteLine("Prompt: " + prompt);
            Console.Write("Your response: ");
            string response = Console.ReadLine();

            // Get current date
            string date = DateTime.Now.ToShortDateString();

            // Create a new entry and add it to the list
            JournalEntry entry = new JournalEntry(prompt, response, date);
            entries.Add(entry);
            Console.WriteLine("Entry added successfully!\n");
        }

        // Method to display the journal
        public void DisplayJournal()
        {
            foreach (var entry in entries)
            {
                Console.WriteLine(entry);
            }
        }

        // Method to save the journal to a file
        public void SaveJournalToFile(string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (var entry in entries)
                    {
                        writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
                    }
                }
                Console.WriteLine("Journal saved to file successfully!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving journal to file: {ex.Message}\n");
            }
        }

        // Method to load the journal from a file
        public void LoadJournalFromFile(string filename)
        {
            try
            {
                string[] lines = File.ReadAllLines(filename);
                foreach (var line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        JournalEntry entry = new JournalEntry(parts[1], parts[2], parts[0]);
                        entries.Add(entry);
                    }
                }
                Console.WriteLine("Journal loaded from file successfully!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading journal from file: {ex.Message}\n");
            }
        }
    }

    // Program class
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        journal.WriteNewEntry();
                        break;
                    case "2":
                        journal.DisplayJournal();
                        break;
                    case "3":
                        Console.Write("Enter the filename to save the journal: ");
                        string saveFilename = Console.ReadLine();
                        journal.SaveJournalToFile(saveFilename);
                        break;
                    case "4":
                        Console.Write("Enter the filename to load the journal: ");
                        string loadFilename = Console.ReadLine();
                        journal.LoadJournalFromFile(loadFilename);
                        break;
                    case "5":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.\n");
                        break;
                }
            }
        }
    }
}
