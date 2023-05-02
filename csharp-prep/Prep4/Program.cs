using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        //The difference between Write() and WriteLine() method is based on new line character. Write() method displays the output but do not provide a new line character. WriteLine() method displays the output and also provides a new line character it the end of the string, This would set a new line for the next output.
        List<int> numbers = new List<int>();

        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.WriteLine("enter a number(or press 0 to quit)");
            
            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);

            if (userNumber != 0)

            {
                numbers.Add(userNumber);
            }

            //summing the numbers 
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }

            Console.WriteLine($"The sum is: {sum}");

            //getting the average
            // By making one of the variables a float first, the computer knows that it has to
            // do the floating point division, and we get the decimal value that we expect.
            float average = ((float)sum) / numbers.Count;
            Console.WriteLine($"The average is: {average}");

            //finding the largest number
             int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                // if this number is greater than the max, we have found the new max!
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
        }

       


    }
}