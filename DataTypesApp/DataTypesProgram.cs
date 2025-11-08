using System;

public class DataTypesProgram
{
    public void Run()
    {
        Console.Write("Enter the pieces of apple: ");
        string applesInput = Console.ReadLine();
        int pieces = int.Parse(applesInput);

        Console.Write("Enter total price of " + pieces + " apple(s): ");
        string priceInput = Console.ReadLine();
        double totalPrice = double.Parse(priceInput);

        Console.WriteLine("The total price of " + pieces + " apple(s) is " + totalPrice);

        Console.WriteLine("The value of original price is " + totalPrice);

        int convertedPrice = (int)totalPrice;
        Console.WriteLine("The value of converted price is " + convertedPrice);

        Console.WriteLine("Press any key to exit.....");
        Console.ReadKey();
    }
}