
public class DeleteCommand : ICommand
{
    public ConColor ConColor = new ConColor();
    public void Execute(CommandContext context, string[] parameters)
    {
        if (parameters.Length == 0)
        {
            ConColor.WriteLine("Error: No parameter was passed. Syntax: delete -alphabetName", ConsoleColor.Red);
            return;
        }
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string folderName = "alphabets";
        string dataName = parameters[0] + ".json";
        string filePath = Path.Combine(currentDirectory, folderName, dataName);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            ConColor.WriteLine($"The alphabet '{parameters[0]}' has been deleted.", ConsoleColor.DarkGreen);
        }
        else
        {
            ConColor.WriteLine($"The alphabet '{parameters[0]}' does not exist.", ConsoleColor.DarkGreen);
        }
    }
}