namespace ECommerce.V1;

public static class Utils
{
    public static string? PromptForInput(string prompt = "", bool newLine = false)
    {
        if (newLine)
            Console.WriteLine(prompt);
        else
            Console.Write(prompt);
        return Console.ReadLine();
    }

    public static void PrintError(string? errorMessage)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(errorMessage);
        Console.ResetColor();
    }
}
