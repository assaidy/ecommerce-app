namespace ECommerce.V1;

public static class Utils
{
    public static string? PromptForInput(string prompt = "", bool newLine = false)
    {
        Console.Write(prompt);
        var input = Console.ReadLine();
        while (string.IsNullOrEmpty(input))
        {
            Utils.PrintError("[Error] Invalid input. Please enter something.");
            Console.Write(prompt);
            input = Console.ReadLine();
        }
        return input;
    }

    public static void PrintError(string? errorMessage)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(errorMessage);
        Console.ResetColor();
    }

    public static void PrintNote(string? noteMessage)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(noteMessage);
        Console.ResetColor();
    }
}
