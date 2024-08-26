public class ExitCommand : ICommand
{
    public void Execute(CommandContext Null, string[] parameters)
    {
        Console.WriteLine("Exiting...");
        Console.WriteLine("Press any button to close...");
        Console.ReadKey();
        Environment.Exit(0);
    }
}