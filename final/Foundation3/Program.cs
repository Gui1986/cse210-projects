using System;

class Event
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Time { get; set; }
    public string Address { get; set; }

    public Event(string title, string description, DateTime date, string time, string address)
    {
        Title = title;
        Description = description;
        Date = date;
        Time = time;
        Address = address;
    }

    public virtual string GenerateMarketingMessage()
    {
        return $"Join us for {Title} on {Date.ToShortDateString()} at {Time}. {Description}. Address: {Address}.";
    }
}

class Lecture : Event
{
    public string Speaker { get; set; }
    public string Topic { get; set; }

    public Lecture(string title, string description, DateTime date, string time, string address, string speaker, string topic)
        : base(title, description, date, time, address)
    {
        Speaker = speaker;
        Topic = topic;
    }

    public override string GenerateMarketingMessage()
    {
        return base.GenerateMarketingMessage() + $" Speaker: {Speaker}. Topic: {Topic}.";
    }
}

class Reception : Event
{
    public string Host { get; set; }
    public int ExpectedGuests { get; set; }

    public Reception(string title, string description, DateTime date, string time, string address, string host, int expectedGuests)
        : base(title, description, date, time, address)
    {
        Host = host;
        ExpectedGuests = expectedGuests;
    }

    public override string GenerateMarketingMessage()
    {
        return base.GenerateMarketingMessage() + $" Host: {Host}. Expected Guests: {ExpectedGuests}.";
    }
}

class OutdoorGathering : Event
{
    public string Theme { get; set; }
    public string Activities { get; set; }

    public OutdoorGathering(string title, string description, DateTime date, string time, string address, string theme, string activities)
        : base(title, description, date, time, address)
    {
        Theme = theme;
        Activities = activities;
    }

    public override string GenerateMarketingMessage()
    {
        return base.GenerateMarketingMessage() + $" Theme: {Theme}. Activities: {Activities}.";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create different types of events
        Event lectureEvent = new Lecture("Tech Talk", "Learn about latest technologies", new DateTime(2024, 4, 15), "10:00 AM", "123 Main St", "John Doe", "Artificial Intelligence");
        Event receptionEvent = new Reception("Company Anniversary", "Celebrate our company's success", new DateTime(2024, 5, 20), "7:00 PM", "456 Oak Ave", "ABC Corp", 100);
        Event outdoorEvent = new OutdoorGathering("Summer Picnic", "Enjoy a fun-filled day outdoors", new DateTime(2024, 6, 30), "11:00 AM", "789 Pine St", "Beach Party", "Games, BBQ, Music");

        // Generate marketing messages for each event
        string lectureMessage = lectureEvent.GenerateMarketingMessage();
        string receptionMessage = receptionEvent.GenerateMarketingMessage();
        string outdoorMessage = outdoorEvent.GenerateMarketingMessage();

        // Display marketing messages
        Console.WriteLine("Marketing Messages:");
        Console.WriteLine(lectureMessage);
        Console.WriteLine(receptionMessage);
        Console.WriteLine(outdoorMessage);
    }
}
