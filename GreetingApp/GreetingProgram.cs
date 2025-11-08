using System;

public class GreetingProgram
{
    public void Run()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Enter the total number of your enrolled courses: ");
        string courses = Console.ReadLine();

        Console.Write("Enter the price of your favorite book: ");
        string bookPrice = Console.ReadLine();

        Console.WriteLine("Name: " + name);
        Console.WriteLine("Total enrolled courses: " + courses);
        Console.WriteLine("Price of my favorite book: " + bookPrice);

        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}