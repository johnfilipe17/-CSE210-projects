using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Whats is your name?");
        string name = Console.ReadLine();
        Console.WriteLine("Whats is your last name?");
        string last_name = Console.ReadLine();
        Console.WriteLine ($"your name is {last_name}, {name} {last_name}.");
    }
}