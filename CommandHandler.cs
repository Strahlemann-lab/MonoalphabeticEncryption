
public class CommandHandler
{
    private Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();
    private CommandContext context = new CommandContext();

    public void RegisterCommand(string commandName, ICommand command)
    {
        commands[commandName] = command;
    }

    public void HandleCommand(string commandName)
    {
        if (commands.ContainsKey(commandName))
        {
            commands[commandName].Execute(context);
        }
        else
        {
            Console.WriteLine("Unknown command: " + commandName);
        }
    }
}