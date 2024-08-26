using System.Reflection.Metadata;

public class CreateCommand : ICommand
{
    public void Execute(CommandContext Null, string[] parameters)
    {
        if (parameters.Length == 0) 
        {
            Console.WriteLine("Error: No parameter was passed. Syntax: create -fileName");
            return;
        }
        
    }
}