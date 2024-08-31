using System.Text.Json;

public class SelectCommand : ICommand
{
    public void Execute(CommandContext context, string[] parameters)
    {
        if (parameters.Length == 0)
        {
            Console.WriteLine("Error: No parameter was passed. Syntax: select -alphabetName");
            return;
        }
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string folderName = "alphabets";
        string dataName = parameters[0] + ".json";
        string filePath = Path.Combine(currentDirectory, folderName, dataName);
        if (File.Exists(filePath))
        {
            string jsonStrng = File.ReadAllText(filePath);
            Dictionary<char, char> SharedDictAlphabet = new Dictionary<char, char>();
            try
            {
                string jsonString = File.ReadAllText(filePath);
                Dictionary<char, char> DictAlphabet = JsonSerializer.Deserialize<Dictionary<char, char>>(jsonString);
                context.SharedDictAlphabet = DictAlphabet;
                context.SharedDictName = parameters[0];
                

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: When loading JSON data: '{ex.Message}'");
            }


            Console.WriteLine($"The alphabet '{parameters[0]}' has been selected.");
        }
        else
        {
            Console.WriteLine($"The alphabet '{parameters[0]}' does not exist.");
        }
    }
}
