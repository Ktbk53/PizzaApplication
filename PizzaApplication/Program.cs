using System.Security.Cryptography.X509Certificates;

public class PizzaApplication
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

    private void AddToOrder(string name, int quantity, double price) 
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
    private double CalcTotal()
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
    /* View Order */

    public void ViewOrder()
    {
        Console.WriteLine("\n--- Current Order ---");

        for (int i = 0; i < ItemCount; i++)
        {
            Console.WriteLine($"{ItemsOrdered[i]} x {ItemQuantities[i]} - ${ItemPrices[i]:F2}");
        }

        Console.WriteLine($"Total: ${CalcTotal():F2}");
    }


    /* Checkout */

    public void Checkout()
    {
        ViewOrder();

        Console.Write("Checkout? (Y/N): ");
        string choice = Console.ReadLine();

        if (choice.ToUpper() == "Y")
        {
            Console.WriteLine("Checkout confirmed.");
            PrintReceipt();
        }
        else
        {
            Console.WriteLine("Checkout cancelled.");
        }
    }


    /* Print Receipt */

    public void PrintReceipt()
    {
        Console.WriteLine("\n--- RECEIPT ---");

        double subtotal = 0;

        for (int i = 0; i < ItemCount; i++)
        {
            double itemTotal = ItemPrices[i] * ItemQuantities[i];
            subtotal += itemTotal;

            Console.WriteLine($"{ItemsOrdered[i]} x {ItemQuantities[i]} - ${itemTotal:F2}");
        }

        double tax = subtotal * 0.06;

        Console.WriteLine($"Subtotal: ${subtotal:F2}");
        Console.WriteLine($"Sales Tax: ${tax:F2}");
        Console.WriteLine($"Total: ${CalcTotal():F2}");
        Console.WriteLine("Thank you for your order!");
    }
}

    



