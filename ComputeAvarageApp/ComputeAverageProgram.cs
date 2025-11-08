using System;

public class ComputeAverageProgram
{
    public void Run()
    {
        Console.WriteLine("Enter 5 grades separated by new line:");
        
        double sum = 0;
        
        for (int i = 0; i < 5; i++)
        {
            double grade = double.Parse(Console.ReadLine());
            sum = sum + grade;
        }
        
        double average = sum / 5;
        
        double roundedAverage = Math.Round(average);
        
        Console.WriteLine("The average is " + average + " and round off to " + roundedAverage);
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}