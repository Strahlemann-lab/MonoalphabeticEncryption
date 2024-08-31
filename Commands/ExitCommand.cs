public class ExitCommand : ICommand
{
    public void Execute(CommandContext context, string[] parameters)
    {
        Console.WriteLine("Exiting...");
        Console.WriteLine("Press any button to close...");
        Console.ReadKey();
        Environment.Exit(0);
    }
}