using System.IO.Enumeration;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

public class ListCommand : ICommand
{
    public ConColor ConColor = new ConColor();
    public void Execute(CommandContext context, string[] parameters)
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string folderName = "alphabets";
        string folder = Path.Combine(currentDirectory, folderName);
        if (parameters.Length == 0)
        {
            if (Directory.Exists(folder))
            {
                string[] fileName = Directory.GetFiles(folder);
                string klickbarerLink = $"{folder.Replace(@"\", "/")}";
                ConColor.WriteLine("Link for the folder.\n" + klickbarerLink + "\n", ConsoleColor.DarkYellow);
                if (fileName == null || fileName.Length == 0) { Console.WriteLine("No alphabets available."); return; }
                Console.WriteLine(string.Format("| {0, -30} | {1, -30} |", "alphabet", "file name"));
                Console.WriteLine("|--------------------------------|--------------------------------|");
                foreach (string i in fileName)
                {
                    string ii = i.Replace(folder, "");
                    ii = ii.Remove(0, 1);
                    string alphabet = ii;
                    alphabet = alphabet.Replace(".json", "");
                    Console.WriteLine(string.Format("| {0, -30} | {1, -30} |", alphabet, ii));
                }
            }
            else { ConColor.WriteLine("Error: No save folder exists! Please restart the program.", ConsoleColor.Red); return; }
        }
        else
        {
            if (parameters.Length == 0)
            {
                ConColor.WriteLine("Error: No parameter was passed. Syntax: list -alphabetName ", ConsoleColor.Red);
                return;
            }
            if (Directory.Exists(folder))
            {
                string[] fileName = Directory.GetFiles(folder);
                string dataName = parameters[0] + ".json";
                string filePath = Path.Combine(currentDirectory, folderName, dataName);
                if (!File.Exists(filePath)) { Console.WriteLine("Error: No alphabet available with name: " + parameters[0], ConsoleColor.Red); return; }
                Console.WriteLine(string.Format("| {0, -5} | {1, -5} |", "Key", "Value"));
                Console.WriteLine("|-------|-------|");
                
                if (File.Exists(filePath))
                {
                    string jsonStrng = File.ReadAllText(filePath);
                    Dictionary<char, char> SharedDictAlphabet = new Dictionary<char, char>();
                    try
                    {
                        string jsonString = File.ReadAllText(filePath);
                        Dictionary<char, char> DictAlphabet = JsonSerializer.Deserialize<Dictionary<char, char>>(jsonString);
                        foreach (char i in DictAlphabet.Keys)
                        {
                            Console.WriteLine(string.Format("| {0, -5} | {1, -5} |", i, DictAlphabet[i]));
                        }


                    }
                    catch (Exception ex)
                    {
                        ConColor.WriteLine($"Error: When loading JSON data: '{ex.Message}'", ConsoleColor.Red);
                    }
                }
            }
            else { ConColor.WriteLine("Error: No save folder exists! Please restart the program.", ConsoleColor.Red); return; }
        }
    }
}
