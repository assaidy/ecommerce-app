namespace ECommerce.V1;

public class App
{
    private List<User> _adminsList = new()
    {
        new("Ahmad Assaidy", "ahmad", "1234"),
        new("Ziad Ahmad", "zizo", "1234"),
    };
    private List<User> _usersList = new()
    {
        new("Muhammad Ali", "moali", "1234"), // just for testing, should be removed
    };

    public void Run()
    {
        EnterTheApp();
    }

    private void EnterTheApp()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Hello, again. Please choose your state to login.");
            Console.WriteLine("  1) Admin");
            Console.WriteLine("  2) User");
            Console.WriteLine("\nChoose one of these options (1-2)");

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
                    case "1":
                        EnterAsAdmin();
                        success = true;
                        break;

                    case "2":
                        EnterAsUser();
                        success = true;
                        break;

                    default:
                        Utils.PrintError($"[Error] Invalid option: '{choice}'. Please choose an option between (1-2)");
                        break;
                }
            }
        }
    }

    private void EnterAsAdmin()
    {
        Console.Clear();
        Console.WriteLine("Hello, Admin. Please Login.");
        string? username = Utils.PromptForInput("username: ");
        string? password = Utils.PromptForInput("password: ");

        var admin = _adminsList.FirstOrDefault(x => x.Username == username && x.Password == password);

        if (admin is null)
        {
            Utils.PrintError("\n[Error] Invalid admin data. Please try again.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nWelcom, admin: '{admin.Name}'");
            Console.ResetColor();
            Console.Write("\nEnter any key to continue...");
            Console.ReadKey();
        }

        while (true)
        {
            // TODO: add admin options 
            // [ ] list product items
            // [ ] search a product item by name
            // [ ] add product item (name, price, description)
            // [ ] modify product item (name, price, description)
            // [ ] remove product item by id
            // NOTE: every product item will have an "internal, auto-generated, unique" id => will appear only to the admin
            // NOTE: if logout => break the loop
        }
    }

    private void EnterAsUser()
    {
        Console.Clear();
        Console.WriteLine("Hello, User. Login or Register?");

        User? user = null;

        var success = false;
        while (!success)
        {
            var choice = Utils.PromptForInput("\nEnter a char, [l]ogin or [r]egister: ");

            switch (choice)
            {
                case "r":
                    user = RegisterUser();
                    success = true;
                    break;

                case "l":
                    user = LoginUser();
                    success = true;
                    break;

                default:
                    Utils.PrintError($"[Error] Invalid option: '{choice}'. Please choose one of options: (l,r)");
                    break;
            }
        }

        if (user is null)
        {
            Utils.PrintError("\n[Error] Invalid user data. Please try again.");
            return;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nWelcom, user: '{user.Name}'");
            Console.ResetColor();
            Console.Write("\nEnter any key to continue...");
            Console.ReadKey();
        }

        while (true)
        {
            // TODO: add user options 
            // [ ] list product items
            // [ ] search a product item by name
            // ...
            // NOTE: if logout => break the loop
        }
    }

    private User? LoginUser()
    {
        string? username = Utils.PromptForInput("username: ");
        string? password = Utils.PromptForInput("password: ");
        return _usersList.FirstOrDefault(x => x.Username == username && x.Password == password);
    }

    private User RegisterUser()
    {
        var name = Utils.PromptForInput("full name: ");
        var username = Utils.PromptForInput("username: ");
        while (_usersList.FirstOrDefault(x => x.Username == username) is not null)
        {
            Utils.PrintError("\n[Error] User exists. Please enter a unique username.\n");
            username = Utils.PromptForInput("username: ");
        }
        var password = Utils.PromptForInput("password: ");

        var newUser = new User(name, username, password);
        _usersList.Add(newUser);

        return newUser;
    }
}
