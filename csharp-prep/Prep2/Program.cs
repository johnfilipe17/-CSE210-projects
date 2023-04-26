using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("what is your grade percentage?");
        string grade = Console.ReadLine();
        int percent = int.Parse(grade);

        string letter = "";

        if (percent >= 90)
        {
            letter ="A"; //("Your grade is A, congratulations!");
        }
    
        else if (percent >=80)
        {
            letter ="B"; //Console.Write("Your grade is B");
        }

        else if (percent <= 70)
        {
            letter ="C";//Console.Write("Your grade is C");
        }

        else if (percent >= 60)
        {
            letter ="D"; //Console.Write("Your grade is D");
        }

        else 
        {
            letter ="F"; //Console.Write("Your grade is F, you failed!");
        }

        Console.WriteLine($"Your grade is {letter}");

        if (percent >=70)
            {
                Console.WriteLine("You passed!!");
            }
        
        else {
            Console.WriteLine("You failed!! You ought to study more.");
        }

    }
}