using System.Security.Cryptography.X509Certificates;

public class main
{
    string[] Pizzas = { "Margherita", "Pepperoni", "Hawaiian", "Veggie", "BBQ Chicken" };
    string[] Drinks = { "Coke", "Pepsi", "Sprite", "Fanta", "Water" };
    double[] PizzaPrices = { 8.99, 9.99, 10.99, 9.49, 11.49 };
    double[] DrinkPrices = { 1.99, 1.99, 1.99, 1.99, 0.99 };
    string[] ItemsOrdered = new string[10];
    int[] ItemQuantities = new int[10];
    double[] ItemPrices = new double[10];
    int ItemCount = 0;


    /* Add to Order */

    public void AddtoOrder(string name, int quantity, double price) 
    {
        if (ItemCount >= 10)
        {
            Console.WriteLine("Order Full");
            return;
        }

        else 
        {
            ItemsOrdered[ItemCount] = name;
            ItemQuantities[ItemCount] = quantity;
            ItemPrices[ItemCount] = price;

            ItemCount++;

            Console.WriteLine($"Added {name} x {quantity} to order");
        }
    }

    /*Total & Sales Tax*/
    public double CalcTotal()
    {
        double Subtotal = 0;
        double Total;

        for (int i = 0; i < ItemCount; i++)
        {
            Subtotal += ItemPrices[i] * ItemQuantities[i];
        }

        double SalesTax = Subtotal * 0.06;
        Total = Subtotal + SalesTax;

        return Total;
    }

}
    



