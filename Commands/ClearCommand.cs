public class ClearCommand : ICommand
{
    public void Execute(CommandContext context, string[] parameters)
    {
        Console.Clear();
    }
}
