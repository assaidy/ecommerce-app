namespace ECommerce.V1;

public static class ProductProcessor
{
    public static void ListProducts(List<ProductItem> productItems, bool isAdmin)
    {
        if (productItems.Count == 0)
        {
            Utils.PrintError("\n[Error] No available products.");
        }
        else
        {
            Console.WriteLine(new string('-', 30)); // just a separator

            foreach (var item in productItems)
                DisplayProductItem(item, isAdmin);

            Utils.PrintNote("[NOTE] please copy the product id you want to modify or remove.");
        }
    }

    private static void DisplayProductItem(ProductItem productItem, bool isAdmin)
    {
        Console.WriteLine($"-> name:        {productItem.Name}");
        Console.WriteLine($"-> description: {productItem.Description}");
        Console.WriteLine($"-> price:       {productItem.Price:C2}");
        if (isAdmin) Console.WriteLine($"-> id:          '{productItem.Id}'");
        Console.WriteLine();
    }

    public static void SearchProduct(List<ProductItem> productItems, bool isAdmin)
    {
        var productName = Utils.PromptForInput("product name: ");

        var searchResults = ProductProcessor.SearchProduct(productItems, productName);
        if (searchResults.Count == 0)
        {
            Utils.PrintError($"\nNo products found with the name: '{productName}'");
        }
        else
        {
            ProductProcessor.ListProducts(searchResults, isAdmin);
        }
    }

    public static List<ProductItem> SearchProduct(List<ProductItem> productItems, string productName)
    {
        List<ProductItem> result = new();
        foreach (var item in productItems)
        {
            if (item.Name.Contains(productName, StringComparison.OrdinalIgnoreCase))
                result.Add(item);
        }
        return result;
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

        decimal id;
        while (!decimal.TryParse(Utils.PromptForInput("\nproduct id: "), out id))
        {
            Utils.PrintError("[Error] Invalid input id. Please enter a valid number.");
        }

        var targetProduct = productItems.FirstOrDefault(x => x.Id == id);
        if (targetProduct is null)
        {
            Utils.PrintError("\n[Error] Couldn't remove item. Product not be found.");
        }
        else
        {
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

        decimal id;
        while (!decimal.TryParse(Utils.PromptForInput("\nproduct id: "), out id))
        {
            Utils.PrintError("[Error] Invalid input id. Please enter a valid number.");
        }

        if (productItems.RemoveAll(x => x.Id == id) == 0)
        {
            Utils.PrintError("\n[Error] Couldn't remove item. Product not be found.");
        }
        else
        {
            Utils.PrintNote("\nProduct removed successfully.");
        }
    }
}
