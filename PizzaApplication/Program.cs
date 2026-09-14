string[] Pizza = { "Margherita", "Pepperoni", "Hawaiian", "Veggie", "BBQ Chicken" };
string[] Drinks = { "Coke", "Pepsi", "Sprite", "Fanta", "Water" };

public class Menu
{
    public string[] GetPizzaMenu()
    {
        return Pizza;
    }
    public string[] GetDrinksMenu()
    {
        return Drinks;
    }
}
public class PizzaOrder
{
    public string PizzaType { get; set; }
    public int Quantity { get; set; }
    public string DrinkType { get; set; }
    public int DrinkQuantity { get; set; }
    public PizzaOrder(string pizzaType, int quantity, string drinkType, int drinkQuantity)
    {
        PizzaType = pizzaType;
        Quantity = quantity;
        DrinkType = drinkType;
        DrinkQuantity = drinkQuantity;
    }
}

public class PizzaAndDrinkPrice
{
    public decimal CalculatePrice(PizzaOrder order)
    {
        decimal pizzaPrice = 0;
        decimal drinkPrice = 0;
        switch (order.PizzaType)
        {
            case "Margherita":
                pizzaPrice = 8.99m;
                break;
            case "Pepperoni":
                pizzaPrice = 9.99m;
                break;
            case "Hawaiian":
                pizzaPrice = 10.99m;
                break;
            case "Veggie":
                pizzaPrice = 9.49m;
                break;
            case "BBQ Chicken":
                pizzaPrice = 11.49m;
                break;
            default:
                throw new ArgumentException("Invalid pizza type");
        }
        switch (order.DrinkType)
        {
            case "Coke":
            case "Pepsi":
            case "Sprite":
            case "Fanta":
                drinkPrice = 1.99m;
                break;
            case "Water":
                drinkPrice = 0.99m;
                break;
            default:
                throw new ArgumentException("Invalid drink type");
        }
        return (pizzaPrice * order.Quantity) + (drinkPrice * order.DrinkQuantity);
    }
}



