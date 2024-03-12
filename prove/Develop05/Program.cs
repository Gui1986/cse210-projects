using System;
using System.Collections.Generic;
using System.IO;

abstract class Goal
{
    public string Name { get; protected set; }
    public int Value { get; protected set; }
    public bool Completed { get; set; } // Make the setter public

    public abstract void MarkComplete();
    public abstract string GetStatus();
    public abstract string GetDetails();
}

class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value)
    {
        Name = name;
        Value = value;
        Completed = false;
    }

    public override void MarkComplete()
    {
        Completed = true;
    }

    public override string GetStatus()
    {
        return Completed ? "[X]" : "[ ]";
    }

    public override string GetDetails()
    {
        return $"{Name}: {Value} points";
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, int value)
    {
        Name = name;
        Value = value;
        Completed = false;
    }

    public override void MarkComplete()
    {
        // Eternal goals are never marked complete
    }

    public override string GetStatus()
    {
        return "Ongoing";
    }

    public override string GetDetails()
    {
        return $"{Name}: {Value} points per completion";
    }
}

class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;

    public ChecklistGoal(string name, int value, int targetCount)
    {
        Name = name;
        Value = value;
        Completed = false;
        this.targetCount = targetCount;
        currentCount = 0;
    }

    public override void MarkComplete()
    {
        currentCount++;
        if (currentCount == targetCount)
        {
            Completed = true;
        }
    }

    public override string GetStatus()
    {
        return Completed ? $"Completed {currentCount}/{targetCount} times" : $"Progress: {currentCount}/{targetCount} times";
    }

    public override string GetDetails()
    {
        return $"{Name}: {Value} points each time, {targetCount} times for bonus";
    }
}

class EternalQuestProgram
{
    private List<Goal> goals = new List<Goal>();
    private int score = 0;

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(int index)
    {
        if (index >= 0 && index < goals.Count)
        {
            Goal goal = goals[index];
            goal.MarkComplete();
            score += goal.Value;
        }
        else
        {
            Console.WriteLine("Invalid goal index!");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Current Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()} {goals[i].GetDetails()}");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Current Score: {score}");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Goal goal in goals)
            {
                outputFile.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Value},{goal.Completed}");
            }
        }
    }

    public void LoadGoals(string filename)
    {
        goals.Clear();
        using (StreamReader inputFile = new StreamReader(filename))
        {
            string line;
            while ((line = inputFile.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                string type = parts[0];
                string name = parts[1];
                int value = int.Parse(parts[2]);
                bool completed = bool.Parse(parts[3]);

                Goal goal;
                switch (type)
                {
                    case "SimpleGoal":
                        goal = new SimpleGoal(name, value);
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal(name, value);
                        break;
                    case "ChecklistGoal":
                        goal = new ChecklistGoal(name, value, 5); // Assuming 5 as default target count
                        break;
                    default:
                        throw new ArgumentException("Invalid goal type!");
                }
                goal.Completed = completed;
                goals.Add(goal);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        EternalQuestProgram program = new EternalQuestProgram();

        // Load goals from file if available
        string filename = "goals.txt";
        if (File.Exists(filename))
        {
            program.LoadGoals(filename);
        }

        // Sample goals
        program.AddGoal(new SimpleGoal("Run a marathon", 1000));
        program.AddGoal(new EternalGoal("Read scriptures", 100));
        program.AddGoal(new ChecklistGoal("Attend the temple", 50, 10));

        // Main menu
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine("1. Record Event");
            Console.WriteLine("2. Display Goals");
            Console.WriteLine("3. Display Score");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    program.DisplayGoals();
                    Console.Write("Enter the index of the goal you completed: ");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    program.RecordEvent(index);
                    break;
                case 2:
                    program.DisplayGoals();
                    break;
                case 3:
                    program.DisplayScore();
                    break;
                case 4:
                    program.SaveGoals(filename);
                    Console.WriteLine("Goals saved successfully!");
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

            Console.WriteLine();
        }
    }
}