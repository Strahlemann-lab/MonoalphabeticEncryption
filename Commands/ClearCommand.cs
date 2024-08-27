public class ClearCommand : ICommand
{
    public void Execute(CommandContext Null, string[] parameters)
    {
        Console.Clear();
    }
}