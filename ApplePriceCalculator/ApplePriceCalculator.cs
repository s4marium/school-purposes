using System;

class Program
{
    static void Main()
    {
        decimal pricePerApple = 32.50m;
        bool looping = true;

        while (looping)
        {
            Console.WriteLine("==================================");
            Console.WriteLine("Welcome to the Apple's Apple Store!");
            Console.WriteLine("==================================\n");
            Console.WriteLine("Please select an option: \n");
            Console.WriteLine("1. Check the price");
            Console.WriteLine("2. Buy apples");
            Console.WriteLine("3. Close the program");
            Console.Write("\nEnter your choice (1-3): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    checkPrice(pricePerApple);
                    break;
                case "2":
                    buyApples(pricePerApple);
                    break;
                case "3":
                    Console.WriteLine("Thank you for visiting the Apple's Apple Store! Goodbye!");
                    looping = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                    break;
            }
            
            Console.WriteLine();
        }
    }

    static void checkPrice(decimal pricePerApple)
    {
        Console.Clear();
        Console.WriteLine($"Each apple costs ${pricePerApple:F2}\n");
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
        Console.Clear();
    }

    static void buyApples(decimal pricePerApple)
    {
        Console.Clear();
        Console.Write("\nEnter the number of apples you want to purchase? : ");
        
        if (int.TryParse(Console.ReadLine(), out int numberOfApples) && numberOfApples > 0)
        {
            decimal totalPrice = numberOfApples * pricePerApple;
            
            int convertedPrice = (int)totalPrice;
            Console.WriteLine("======================================================");
            Console.WriteLine($"The total price of {numberOfApples} apples is ${totalPrice:F2}.");
            Console.WriteLine($"The value of the converted price is ${convertedPrice}.");
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a positive number.");
        }
    }
}
