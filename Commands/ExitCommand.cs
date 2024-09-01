public class ExitCommand : ICommand
{
    public ConColor ConColor = new ConColor();
    public void Execute(CommandContext context, string[] parameters)
    {
        ConColor.WriteLine("Exiting...", ConsoleColor.DarkRed);
        ConColor.WriteLine("Press any button to close...", ConsoleColor.DarkRed);
        Console.ReadKey();
        Environment.Exit(0);
    }
}