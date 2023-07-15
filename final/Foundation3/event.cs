using System;

// Base Event class
public class Event
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    public string Address { get; set; }

    public string GenerateStandardDetails()
    {
        return $"Title: {Title}\nDescription: {Description}\nDate: {Date}\nTime: {Time}\nAddress: {Address}\n";
    }

    public virtual string GenerateFullDetails()
    {
        return GenerateStandardDetails();
    }

    public string GenerateShortDescription()
    {
        return $"Type: Event\nTitle: {Title}\nDate: {Date}\n";
    }
}

// Lecture class (derived from Event)
public class Lecture : Event
{
    public string Speaker { get; set; }
    public int Capacity { get; set; }

    public override string GenerateFullDetails()
    {
        string baseDetails = base.GenerateFullDetails();
        return $"{baseDetails}Speaker: {Speaker}\nCapacity: {Capacity}\n";
    }
}

// Reception class (derived from Event)
public class Reception : Event
{
    public string RSVP { get; set; }

    public override string GenerateFullDetails()
    {
        string baseDetails = base.GenerateFullDetails();
        return $"{baseDetails}RSVP: {RSVP}\n";
    }
}

// OutdoorGathering class (derived from Event)
public class OutdoorGathering : Event
{
    public string WeatherForecast { get; set; }

    public override string GenerateFullDetails()
    {
        string baseDetails = base.GenerateFullDetails();
        return $"{baseDetails}Weather Forecast: {WeatherForecast}\n";
    }
}

public class Program
{
    public static void Main()
    {
        // Creating objects for each event type
        Event event1 = new Event
        {
            Title = "Generic Event",
            Description = "Description of the event",
            Date = "2023-07-01",
            Time = "12:00 PM",
            Address = "123 Main St, City, State, 12345"
        };
        Console.WriteLine(event1.GenerateStandardDetails());
        Console.WriteLine(event1.GenerateFullDetails());
        Console.WriteLine(event1.GenerateShortDescription());

        Lecture lecture1 = new Lecture
        {
            Title = "Inspirational Talk",
            Description = "Learn and get inspired!",
            Date = "2023-07-02",
            Time = "2:00 PM",
            Address = "456 Park Ave, City, State, 67890",
            Speaker = "John Smith",
            Capacity = 100
        };
        Console.WriteLine(lecture1.GenerateStandardDetails());
        Console.WriteLine(lecture1.GenerateFullDetails());
        Console.WriteLine(lecture1.GenerateShortDescription());

        Reception reception1 = new Reception
        {
            Title = "Networking Event",
            Description = "Network with industry professionals",
            Date = "2023-07-03",
            Time = "6:00 PM",
            Address = "789 Broadway, City, State, 13579",
            RSVP = "rsvp@example.com"
        };
        Console.WriteLine(reception1.GenerateStandardDetails());
        Console.WriteLine(reception1.GenerateFullDetails());
        Console.WriteLine(reception1.GenerateShortDescription());

        OutdoorGathering gathering1 = new OutdoorGathering
        {
            Title = "Picnic in the Park",
            Description = "Enjoy a fun-filled day outdoors",
            Date = "2023-07-04",
            Time = "10:00 AM",
            Address = "987 Lakeview Rd, City, State, 24680",
            WeatherForecast = "Sunny"
        };
        Console.WriteLine(gathering1.GenerateStandardDetails());
        Console.WriteLine(gathering1.GenerateFullDetails());
        Console.WriteLine(gathering1.GenerateShortDescription());
    }
}
