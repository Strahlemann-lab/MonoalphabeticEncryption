
public class DeleteCommand : ICommand
{
    public void Execute(CommandContext context, string[] parameters)
    {
        if (parameters.Length == 0)
        {
            Console.WriteLine("Error: No parameter was passed. Syntax: delete -alphabetName");
            return;
        }
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string folderName = "alphabets";
        string dataName = parameters[0] + ".json";
        string filePath = Path.Combine(currentDirectory, folderName, dataName);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Console.WriteLine($"The alphabet '{parameters[0]}' has been deleted.");
        }
        else
        {
            Console.WriteLine($"The alphabet '{parameters[0]}' does not exist.");
        }
    }
}