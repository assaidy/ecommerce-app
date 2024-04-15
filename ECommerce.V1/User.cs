namespace ECommerce.V1;

public class User
{
    private List<ProductItem> _cart;

    public string? Name { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }

    public User(string? name, string? username, string? password)
    {
        Name = name;
        Username = username;
        Password = password;
        _cart = new();
    }

    // NOTE:: this option will appear afte listing and searching
    public void AddItemToCart(List<ProductItem> productItems)
    {
        int index;
        while (!int.TryParse(Utils.PromptForInput("product number: "), out index))
        {
            Utils.PrintError("[Error] Invalid input number. Please enter a valid number.");
        }

        index--;
        if (index < 0 || index >= productItems.Count)
        {
            Utils.PrintError("\n[Error] Couldn't find item with this number.");
            return;
        }

        var checkIfAdded = _cart.FirstOrDefault(x => x.Equals(productItems[index]));
        if (checkIfAdded is not null)
        {
            Console.WriteLine(checkIfAdded.Name);
            Utils.PrintError("\n[Error] Product is already added to cart.");
            return;
        }

        _cart.Add(productItems[index]);
        Utils.PrintNote("\nAdded to cart successfully.");
    }

    public void DisplayCartItems()
    {
        if (!_cart.Any())
        {
            Utils.PrintError("\n[Error] Cart is empty. Please by some products.");
            return;
        }

        ProductProcessor.ListProducts(_cart);

        var loopShouldRun = true;
        while (loopShouldRun)
        {
            Console.WriteLine();
            Console.WriteLine("Manage cart: ");
            Console.WriteLine("  1) Purchase an item");
            Console.WriteLine("  2) Remove an item");
            Console.WriteLine("  3) cancel");
            Console.WriteLine("\nPlease choose an option between (1-3)");

            var success = false;
            while (!success)
            {
                var choice = Utils.PromptForInput(">> ");

                switch (choice)
                {
                    case "1": // purchase item
                        PurchaseItem();
                        success = true;
                        break;
                    case "2": // remove item from cart
                        RemoveItemFromCart();
                        success = true;
                        break;
                    case "3": // cancel
                        loopShouldRun = false;
                        success = true;
                        break;
                    default:
                        Utils.PrintError($"[Error] Invalid option: '{choice}'. Please choose an option between (1-3)");
                        break;
                }
            }
        }
    }

    // NOTE: this option will appear after after displaying cart
    public void RemoveItemFromCart()
    {
        if (!_cart.Any())
        {
            Utils.PrintError("\n[Error] Cart is empty. Please by some products.");
            return;
        }


        int index;
        while (!int.TryParse(Utils.PromptForInput("product number: "), out index))
        {
            Utils.PrintError("[Error] Invalid input number. Please enter a valid number.");
        }

        index--;
        if (index < 0 || index >= _cart.Count)
        {
            Utils.PrintError("\n[Error] Couldn't find item with this number.");
            return;
        }

        _cart.RemoveAt(index);
        Utils.PrintNote("\nRemoved successfully.");
    }

    // NOTE: this option will appear after after displaying cart
    public void PurchaseItem()
    {
        if (!_cart.Any())
        {
            Utils.PrintError("\n[Error] Cart is empty. Please by some products.");
            return;
        }


        int index;
        while (!int.TryParse(Utils.PromptForInput("product number: "), out index))
        {
            Utils.PrintError("[Error] Invalid input number. Please enter a valid number.");
        }

        index--;
        if (index < 0 || index >= _cart.Count)
        {
            Utils.PrintError("\n[Error] Couldn't find item with this number.");
            return;
        }

        _cart.RemoveAt(index);
        Utils.PrintNote("\nPurchased successfully.");
    }
}
