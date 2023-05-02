using System;

class Program
{
    static void Main(string[] args)
    {    
        DisplayMessage();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);
        DisplayResult(userName, userNumber,squaredNumber);
    }
    
    static void DisplayMessage(){
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName() {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int PromptUserNumber()
     {
        Console.Write("enter your favorite number:");
        int number = int.Parse(Console.ReadLine());
        
        return number;
    }
        
    static int SquareNumber (int number){
        int square = number * number;
        return square;
    }

    static void DisplayResult (String name, int number, int square){
        Console.WriteLine($"Hi, {name}. Your favorite number is {number} and its square number is {square}");
    } 
    
}