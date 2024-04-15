namespace ECommerce.V1;

public static class ProductProcessor
{
    public static bool ListProducts(List<ProductItem> productItems)
    {
        if (productItems.Count == 0)
        {
            Utils.PrintError("\n[Error] No available products.");
            return false;
        }

        Console.WriteLine(new string('-', 30)); // just a separator
        for (int i = 0; i < productItems.Count; i++)
        {
            Console.WriteLine($"-> {i + 1}");
            DisplayProductItem(productItems[i]);
        }
        Utils.PrintNote("[NOTE] please copy number of the product you want.");

        return true;
    }

    private static void DisplayProductItem(ProductItem productItem)
    {
        Console.WriteLine($"-> name:        {productItem.Name}");
        Console.WriteLine($"-> description: {productItem.Description}");
        Console.WriteLine($"-> price:       {productItem.Price:C2}");
        Console.WriteLine();
    }

    public static bool SearchProduct(List<ProductItem> productItems)
    {
        var productName = Utils.PromptForInput("product name: ");

        var searchChecker = productItems.FirstOrDefault(x => x.Name.Contains(productName, StringComparison.OrdinalIgnoreCase));
        if (searchChecker is null)
        {
            Utils.PrintError($"\nNo products found with the name: '{productName}'");
            return false;
        }

        Console.WriteLine(new string('-', 30)); // just a separator
        for (int i = 0; i < productItems.Count; i++)
        {
            if (productItems[i].Name.Contains(productName, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"-> {i + 1}");
                DisplayProductItem(productItems[i]);
            }
        }
        Utils.PrintNote("[NOTE] please copy number of the product you want.");

        return true;
    }

    public static void AddProduct(List<ProductItem> productItems)
    {
        var name = Utils.PromptForInput("prduct name: ");
        if (productItems.FirstOrDefault(x => x.Name == name) is not null)
        {
            Utils.PrintError("\n[Error] Product already exists.");
            return;
        }

        decimal price;
        while (!decimal.TryParse(Utils.PromptForInput("price: "), out price))
        {
            Utils.PrintError("[Error] Invalid input price. Please enter a valid number.");
        }

        var description = Utils.PromptForInput("description: ");

        productItems.Add(new(name, price, description));
    }

    public static void ModifyProduct(List<ProductItem> productItems)
    {
        if (productItems.Count == 0)
        {
            Utils.PrintError("\n[Error] No available products.");
            return;
        }

        int index;
        while (!int.TryParse(Utils.PromptForInput("\nproduct number: "), out index))
        {
            Utils.PrintError("[Error] Invalid input number. Please enter a valid number.");
        }

        index--;
        if (index < 0 || index >= productItems.Count)
        {
            Utils.PrintError("[Error] Couldn't find item. Invalid item number.");
        }
        else
        {
            var targetProduct = productItems[index];
            Console.WriteLine("  1) modify name");
            Console.WriteLine("  2) modify price");
            Console.WriteLine("  3) modify description");
            Console.WriteLine("  4) cancel");
            Console.WriteLine("\nChoose one of these options (1-4)");

            var success = false;
            while (!success)
            {
                var choice = Utils.PromptForInput(">> ");

                switch (choice)
                {
                    case "1": // modify name
                        Console.WriteLine($"old name: {targetProduct.Name}");
                        var newName = Utils.PromptForInput("new name: ");
                        while (productItems.FirstOrDefault(x => x.Name == newName) is not null)
                        {
                            Utils.PrintError("[Error] Found a product with similar name. Please choose a nother name");
                            newName = Utils.PromptForInput("new name: ");
                        }
                        targetProduct.Name = newName;
                        Utils.PrintNote("\nProduct modified successfully.");
                        success = true;
                        break;

                    case "2": // modify price
                        Console.WriteLine($"old price: {targetProduct.Price}");
                        decimal newPrice;
                        while (!decimal.TryParse(Utils.PromptForInput("new price: "), out newPrice))
                        {
                            Utils.PrintError("[Error] Invalid input price. Please enter a valid number.");
                        }
                        targetProduct.Price = newPrice;
                        Utils.PrintNote("\nProduct modified successfully.");
                        success = true;
                        break;

                    case "3": // modify description
                        Console.WriteLine($"old description: {targetProduct.Description}");
                        var newDescription = Utils.PromptForInput("new description: ");
                        targetProduct.Description = newDescription;
                        Utils.PrintNote("\nProduct modified successfully.");
                        success = true;
                        break;

                    case "4": // cancel
                        success = true;
                        break;

                    default:
                        Utils.PrintError($"[Error] Invalid option: '{choice}'. Please choose an option between (1-4)");
                        break;

                }
            }
        }
    }

    public static void RemoveProduct(List<ProductItem> productItems)
    {
        if (productItems.Count == 0)
        {
            Utils.PrintError("\n[Error] No available products.");
            return;
        }

        int index;
        while (!int.TryParse(Utils.PromptForInput("\nproduct number: "), out index))
        {
            Utils.PrintError("[Error] Invalid input number. Please enter a valid number.");
        }

        index--;
        if (index < 0 || index >= productItems.Count)
        {
            Utils.PrintError("[Error] Couldn't find item. Invalid item number.");
        }
        else
        {
            productItems.RemoveAt(index);
            Utils.PrintNote("\nProduct removed successfully.");
        }
    }
}
