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


        // Program starts here - Jason
        static void Main(string[] args)
        {
            PizzaApplication app = new PizzaApplication();
            app.MainMenu();
        }

        // Main Menu - Jason
        void MainMenu()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                TitleAscii();
                Console.WriteLine("\n===Main Menu===\n");
                Console.WriteLine("1. Order Pizza");
                Console.WriteLine("2. Order Drinks");
                Console.WriteLine("3. View Order");
                Console.WriteLine("4. Checkout");
                Console.WriteLine("5. Exit\n");

                Console.Write("Please enter your choice: ");

                string input = Console.ReadLine();
                int choice;

                if (int.TryParse(input, out choice) && choice >= 1 && choice <= 5)
                {
                    switch (choice)
                    {
                        case 1:
                            OrderPizza();
                            break;

                        case 2:
                            OrderDrinks();
                            break;

                        case 3:
                            Console.Clear();
                            ViewOrder();
                            Console.ReadLine();
                            break;

                        case 4:
                            Console.Clear();
                            Checkout();
                            Console.ReadLine();
                            break;

                        case 5:
                            running = false;
                            Console.Clear();
                            Console.WriteLine("===Exit Screen===\n");
                            Console.WriteLine("Thank you for using the PizzaApp!\n");
                            Console.WriteLine("Have a nice day!");
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("\nSorry, please enter a number 1 through 5 for your choice.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        //Order Pizza - Jason
        void OrderPizza()
        {
            //Loops to check user Pizza input
            while (true)
            {
                //Prints Menu
                Console.Clear();
                Console.WriteLine("\n===Order Pizza Menu===\n");

                for (int i = 0; i < Pizzas.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {Pizzas[i]} - {PizzaPrices[i]:C}");
                }

                Console.Write("\nPlease select a pizza: ");

                string input = Console.ReadLine();
                int pizzaChoice;

                //Pizza Input Check
                if (int.TryParse(input, out pizzaChoice) && pizzaChoice >= 1 && pizzaChoice <= 10)
                {
                    Console.WriteLine($"You selected: {Pizzas[pizzaChoice - 1]} - {PizzaPrices[pizzaChoice - 1]:C}");
                    int quantity;

                    //Loops to check user quantity input
                    while (true)
                    {
                        Console.Write("\nPlease enter a quantity: ");
                        string quantityInput = Console.ReadLine();

                        //Quantiy Input Check
                        if (int.TryParse(quantityInput, out quantity) && quantity > 0)
                        {
                            break;
                        }
                        else
                            Console.WriteLine("Invalid quantity. Please enter a number greater than zero.");
                    }

                    AddToOrder(Pizzas[pizzaChoice - 1], quantity, PizzaPrices[pizzaChoice - 1]);
                    Console.ReadLine();
                    break;

                }
                else
                {
                    Console.WriteLine($"Sorry, please enter a number from 1 to {PizzaPrices.Length}.");
                    Console.ReadLine();

                }
            }
        }

        //Order Drinks - Jason
        void OrderDrinks()
        {
            //Loops to check Drinks input
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n===Order Drinks Menu===\n");

                for (int i = 0; i < Drinks.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {Drinks[i]} - {DrinkPrices[i]:C}");
                }

                Console.Write("\nPlease select a drink: ");

                string input = Console.ReadLine();
                int drinkChoice;

                //Drinks input check
                if (int.TryParse(input, out drinkChoice) &&
                    drinkChoice >= 1 &&
                    drinkChoice <= 10)
                {
                    Console.WriteLine(
                        $"You selected: {Drinks[drinkChoice - 1]} - {DrinkPrices[drinkChoice - 1]:C}"
                    );

                    int quantity;

                    //Loops to check quantity input
                    while (true)
                    {
                        Console.Write("\nPlease enter a quantity: ");
                        string quantityInput = Console.ReadLine();

                        //Quantity input check
                        if (int.TryParse(quantityInput, out quantity) &&
                            quantity > 0)
                        {
                            break;
                        }
                        else
                            Console.WriteLine("Invalid quantity. Please enter a number greater than zero.");
                    }

                    AddToOrder(
                        Drinks[drinkChoice - 1],
                        quantity,
                        DrinkPrices[drinkChoice - 1]
                    );

                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine(
                        $"Sorry, please enter a number from 1 to {Drinks.Length}."
                    );

                    Console.ReadLine();
                }
            }

        }
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

        //Just a fun stupid title I made for the app main screen - Jason
        void TitleAscii()
        {
            Console.WriteLine();
            Console.WriteLine("       ^         || =                                         //      ");
            Console.WriteLine("      / \\        ||   =                                      // \\\\        ");
            Console.WriteLine("     /   \\       ||    ||  O   =====  =====     //          //   \\\\     ||==   ||==  ");
            Console.WriteLine("    / O   \\      ||   =           //     //    // \\\\       //     \\\\    ||  || ||  ||");
            Console.WriteLine("   /     O \\     || =      ||    //     //    //   \\\\     // ===== \\\\   ||==   ||== ");
            Console.WriteLine("  /  O      \\    ||        ||   //     //    // === \\\\   //         \\\\  ||     ||   ");
            Console.WriteLine(" ###    O   ###  ||        ||  =====  ===== //       \\\\ //           \\\\ ||     || ");
            Console.WriteLine("   ##########");
        }
    }

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

    



