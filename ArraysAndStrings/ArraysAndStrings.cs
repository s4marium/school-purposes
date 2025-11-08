using System;

public class ArraysAndStrings
{
    public static void Main(string[] args)
    {
        Console.WriteLine("1. Classmate Names (One-dimensional Array):");
        string[] classmates = ["Red", "Rickmer", "James", "Christian", "Rain", "Shaine"];
        foreach (var name in classmates)
        {
            Console.WriteLine($"- {name}");
        }

        Console.WriteLine();

        Console.WriteLine("2. Letter Grid (Two-dimensional Array - 2x3):");
        char[,] letterGrid = { { 'A', 'B', 'C' }, { 'D', 'E', 'F' } };

        for (int row = 0; row < letterGrid.GetLength(0); row++)
        {
            for (int col = 0; col < letterGrid.GetLength(1); col++)
            {
                Console.Write($"{letterGrid[row, col]} ");
            }
            Console.WriteLine();
        }

        Console.WriteLine();

        Console.WriteLine("3. String Analysis:");
        const string TestMessage = "Hello, this my project in C# programming!";

        Console.WriteLine($"Message: \"{TestMessage}\"");

        bool containsHello = TestMessage.Contains("hello", StringComparison.OrdinalIgnoreCase);
        Console.WriteLine($"Contains 'hello' (case-insensitive): {containsHello}");

        int helloIndex = TestMessage.IndexOf("hello", StringComparison.OrdinalIgnoreCase);
        Console.WriteLine($"Position of 'hello': {(helloIndex >= 0 ? helloIndex.ToString() : "Not found")}");
    
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}

