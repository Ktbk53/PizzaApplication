using System.Security.Cryptography.X509Certificates;

public class main
{
    static string[] Pizzas = { "Margherita", "Pepperoni", "Hawaiian", "Veggie", "BBQ Chicken" };
    static string[] Drinks = { "Coke", "Pepsi", "Sprite", "Fanta", "Water" };
    static double[] PizzaPrices = { 8.99, 9.99, 10.99, 9.49, 11.49 };
    static double[] DrinkPrices = { 1.99, 1.99, 1.99, 1.99, 0.99 };
    static string[] ItemsOrdered = new string[10];
    static int[] ItemQuantities = new int[10];
    static double[] ItemPrices = new double[10];
    static int ItemCount = 0;


    /* Add to Order */

    static void AddtoOrder(string name, int quantity, double price) 
    {
        if (ItemCount < 10)
        {
            ItemsOrdered[ItemCount] = name;
            ItemQuantities[ItemCount] = quantity;
            ItemPrices[ItemCount] = price;

            ItemCount++;

            Console.WriteLine($"Added {name} x {quantity} to order");
        }

        else 
        {
            Console.WriteLine("Order Full");
        }
    }

}
    



