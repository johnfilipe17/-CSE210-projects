using System;

class Program
{
    static void Main(string[] args)
    {
        /*parts 1 and 2 where the user chooses number 
        Console.Write("What is the magic number?");
        int number = int.Parse(Console.ReadLine());
        Console.Write("Take a guess:");
        int guess = int.Parse(Console.ReadLine());

        if (guess > number)
        {
            Console.Write("Lower!");
        }

        else if (guess < number) 
        {
            Console.Write("Higher!");
        }

        else 
        {
            Console.Write("You guessed it right!");
        }*/

        //part 3 where we use a random number 
        Console.Write("Press any key to play");
        int guess = int.Parse(Console.ReadLine());
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1,101);


        while (guess != number)
        {
            Console.Write("what is your guess?");
            guess = int.Parse(Console.ReadLine()); 

            if (guess > number)
            {
            Console.Write("Lower!");
            }

            else if (guess < number) 
            {
            Console.Write("Higher!");
            }

            else 
            {
            Console.Write("You guessed it right!");
            }
        }

    }

    
}

