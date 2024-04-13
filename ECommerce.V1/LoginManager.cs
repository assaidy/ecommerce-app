namespace ECommerce.V1;

public static class LoginManager
{
    public static User? LoginUser(List<User> usersList)
    {
        string? username = Utils.PromptForInput("username: ");
        string? password = Utils.PromptForInput("password: ");
        return usersList.FirstOrDefault(x => x.Username == username && x.Password == password);
    }

    public static User RegisterUser(List<User> usersList)
    {
        var name = Utils.PromptForInput("full name: ");
        var username = Utils.PromptForInput("username: ");
        while (usersList.FirstOrDefault(x => x.Username == username) is not null)
        {
            Utils.PrintError("\n[Error] User exists. Please enter a unique username.\n");
            username = Utils.PromptForInput("username: ");
        }
        var password = Utils.PromptForInput("password: ");

        var newUser = new User(name, username, password);
        usersList.Add(newUser);

        return newUser;
    }
}
