namespace ECommerce.V1;

// TODO: move from list to dictionary<key=username/id, value=User/ProductItem> (faster access/search)
// TODO: make choosing options more dynamic/reusable
public class App
{
    private List<User> _adminsList = new()
    {
        new("Ahmad Assaidy", "ahmad", "1234"),
        new("Ziad Ahmad", "zizo", "1234"),
    };
    private List<User> _usersList = new();
    // {
    // new("Muhammad Ali", "moali", "1234"), // just for testing, should be removed
    // };
    private List<ProductItem> _stock = new()
    {
        new("iPhone 1", 20000m, "smart phone from Apple"),
        new("iPhone 2", 30000m, "smart phone from Apple"),
        new("so good they can't ignore you", 20m, "a hard cover book on self improvement"),
    };

    public void Run()
    {
        EnterTheApp();
    }

    private void EnterTheApp()
    {
        var isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("Hello, again. Please choose your state to login.");
            Console.WriteLine("  1) Admin");
            Console.WriteLine("  2) Customer");
            Console.WriteLine("  3) Exit");
            Console.WriteLine("\nChoose one of these options (1-3)");

            var success = false;
            while (!success)
            {
                // int choice;
                // while (!int.TryParse(Utils.PromptForInput(">> "), out choice))
                // {
                //     Utils.PrintError($"[Error] Invalid input: '{choice}'. Please enter an integer.");
                // }

                var choice = Utils.PromptForInput(">> ");

                switch (choice)
                {
                    case "1": // admin
                        EnterAsAdmin();
                        success = true;
                        break;

                    case "2": // customer
                        EnterAsCustomer();
                        success = true;
                        break;

                    case "3": // exit
                        isRunning = false;
                        success = true;
                        break;

                    default:
                        Utils.PrintError($"[Error] Invalid option: '{choice}'. Please choose an option between (1-3)");
                        break;
                }
            }
        }
    }

    private void EnterAsAdmin()
    {
        Console.Clear();
        Console.WriteLine("Hello, Admin. Please Login.");

        var admin = LoginManager.LoginUser(_adminsList);

        if (admin is null)
        {
            Utils.PrintError("\n[Error] Invalid admin data. Please try again.");
            Console.Write("\nEnter any key to continue...");
            Console.ReadKey();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nWelcom, admin: '{admin.Name}'");
            Console.ResetColor();

            var loggedIn = true;
            while (loggedIn)
            {
                Console.Clear();
                Console.WriteLine("Admin Options:");
                Console.WriteLine("  1) list products");
                Console.WriteLine("  2) search a product by name");
                Console.WriteLine("  3) add a product");
                Console.WriteLine("  4) modify a product by id");
                Console.WriteLine("  5) remove a product by id");
                Console.WriteLine("  6) logout");
                Console.WriteLine("\nChoose one of these options (1-5)");

                var success = false;
                while (!success)
                {
                    var choice = Utils.PromptForInput(">> ");

                    switch (choice)
                    {
                        // FIX: 
                        // [ ] change the way of listing => depend on numbers(indeces) not id
                        // [X] display options (modify, remove, cancel) after listing
                        case "1": // list products
                            ProductProcessor.ListProducts(_stock, true);
                            success = true;
                            break;

                        case "2": // search a product by name
                            ProductProcessor.SearchProduct(_stock, true);
                            success = true;
                            break;

                        case "3": // add a product
                            ProductProcessor.AddProduct(_stock);
                            success = true;
                            break;

                        case "4": // modify a product by id
                            ProductProcessor.ListProducts(_stock, true);
                            ProductProcessor.ModifyProduct(_stock);
                            success = true;
                            break;

                        case "5": // remove a product by id
                            ProductProcessor.ListProducts(_stock, true);
                            ProductProcessor.RemoveProduct(_stock);
                            success = true;
                            break;

                        case "6": // logout
                            loggedIn = false;
                            success = true;
                            break;

                        default:
                            Utils.PrintError($"[Error] Invalid option: '{choice}'. Please choose an option between (1-6)");
                            break;
                    }
                }

                Console.Write("\nEnter any key to continue...");
                Console.ReadKey();
            }
        }
    }

    private void EnterAsCustomer()
    {
        Console.Clear();
        Console.WriteLine("Hello, customer. Login or Register?");

        User? customer = null;

        var success = false;
        while (!success)
        {
            var choice = Utils.PromptForInput("\nEnter a char, [l]ogin or [r]egister: ");

            switch (choice)
            {
                case "r":
                    customer = LoginManager.RegisterUser(_usersList);
                    success = true;
                    break;

                case "l":
                    customer = LoginManager.LoginUser(_usersList);
                    success = true;
                    break;

                default:
                    Utils.PrintError($"[Error] Invalid option: '{choice}'. Please choose one of options: (l,r)");
                    break;
            }
        }

        if (customer is null)
        {
            Utils.PrintError("\n[Error] Invalid customer data. Please try again.");
            return;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nWelcom, customer: '{customer.Name}'");
            Console.ResetColor();
            Console.Write("\nEnter any key to continue...");
            Console.ReadKey();
        }

        while (true)
        {
            // TODO: add customer options 
            // [ ] list product items
            // [ ] search a product item by name
            // ...
            // NOTE: if logout => break the loop
        }
    }
}
