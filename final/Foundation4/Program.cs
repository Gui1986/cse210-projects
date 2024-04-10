using System;

abstract class Exercise
{
    public DateTime Date { get; set; }
    public string Type { get; protected set; }
    public TimeSpan Duration { get; set; }

    public Exercise(DateTime date, TimeSpan duration)
    {
        Date = date;
        Duration = duration;
    }

    public abstract double CalculateDistance();
    public abstract double CalculateSpeed();
    public abstract TimeSpan CalculatePace();

    public virtual void DisplaySummary()
    {
        Console.WriteLine($"Date: {Date.ToShortDateString()}");
        Console.WriteLine($"Type: {Type}");
        Console.WriteLine($"Duration: {Duration}");
        Console.WriteLine($"Distance: {CalculateDistance()} km");
        Console.WriteLine($"Speed: {CalculateSpeed()} km/h");
        Console.WriteLine($"Pace: {CalculatePace()} per km");
    }
}

class Running : Exercise
{
    public double Distance { get; set; }

    public Running(DateTime date, TimeSpan duration, double distance)
        : base(date, duration)
    {
        Type = "Running";
        Distance = distance;
    }

    public override double CalculateDistance()
    {
        return Distance;
    }

    public override double CalculateSpeed()
    {
        return Distance / Duration.TotalHours;
    }

    public override TimeSpan CalculatePace()
    {
        return TimeSpan.FromMinutes(Duration.TotalMinutes / Distance);
    }
}

class Cycling : Exercise
{
    public double Distance { get; set; }

    public Cycling(DateTime date, TimeSpan duration, double distance)
        : base(date, duration)
    {
        Type = "Cycling";
        Distance = distance;
    }

    public override double CalculateDistance()
    {
        return Distance;
    }

    public override double CalculateSpeed()
    {
        return Distance / Duration.TotalHours;
    }

    public override TimeSpan CalculatePace()
    {
        return TimeSpan.FromMinutes(Duration.TotalMinutes / Distance);
    }
}

class Swimming : Exercise
{
    public double Distance { get; set; }

    public Swimming(DateTime date, TimeSpan duration, double distance)
        : base(date, duration)
    {
        Type = "Swimming";
        Distance = distance;
    }

    public override double CalculateDistance()
    {
        return Distance;
    }

    public override double CalculateSpeed()
    {
        return Distance / Duration.TotalHours;
    }

    public override TimeSpan CalculatePace()
    {
        return TimeSpan.FromMinutes(Duration.TotalMinutes / Distance);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create exercise instances
        Exercise runningExercise = new Running(new DateTime(2024, 4, 1), TimeSpan.FromMinutes(45), 5.5);
        Exercise cyclingExercise = new Cycling(new DateTime(2024, 4, 3), TimeSpan.FromMinutes(60), 15.3);
        Exercise swimmingExercise = new Swimming(new DateTime(2024, 4, 5), TimeSpan.FromMinutes(30), 1.2);

        // Display exercise summaries
        Console.WriteLine("Exercise Summaries:");
        runningExercise.DisplaySummary();
        Console.WriteLine();
        cyclingExercise.DisplaySummary();
        Console.WriteLine();
        swimmingExercise.DisplaySummary();
    }
}
