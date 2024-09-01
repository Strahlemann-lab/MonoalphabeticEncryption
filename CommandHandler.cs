
public class CommandHandler
{
    private Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();
    private CommandContext context = new CommandContext();
    public ConColor ConColor = new ConColor();

    public void RegisterCommand(string commandName, ICommand command)
    {
        commands[commandName] = command;
    }

    public void HandleCommand(string input)
    {
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0)
        {
            ConColor.WriteLine("Error: No command entered.", ConsoleColor.Red);
            return;
        }
        string commandName = parts[0];
        List<string> parameters = new List<string>();
        if (commands.ContainsKey(commandName))
        {
            if (parts.Length > 1)
            {
                for (int i = 1; i < parts.Length; i++)
                {
                    if (!parts[i].StartsWith("-"))
                    {
                        ConColor.WriteLine($"Error: Parameter '{parts[i]}' must start with '-'.", ConsoleColor.Red);
                        return;
                    }
                    parts[i] = parts[i].Substring(1);
                    parameters.Add(parts[i]);
                    
                }
            }
            commands[commandName].Execute(context, parameters.ToArray());
        }
        else
        {
            ConColor.WriteLine("Unknown command: " + commandName, ConsoleColor.Red);
        }
    }
}


// [CommandName] -[parameter] -[parameter] ...
