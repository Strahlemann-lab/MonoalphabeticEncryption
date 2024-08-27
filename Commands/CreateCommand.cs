using System.Reflection.Metadata;
using System.Text.Json;

public class CreateCommand : ICommand
{
    public void Execute(CommandContext Null, string[] parameters)
    {
        if (parameters.Length == 0)
        {
            Console.WriteLine("Error: No parameter was passed. Syntax: create -fileName");
            return;
        }
        Dictionary<char, char> dictAlphabet = new Dictionary<char, char>();
        for (char c = 'A'; c <= 'Z'; c++)
        {
            dictAlphabet.Add(c, '#');
        }
        dictAlphabet.Add('ä', '#');
        dictAlphabet.Add('ü', '#');
        dictAlphabet.Add('ö', '#');
        dictAlphabet.Add('.', '#');
        dictAlphabet.Add(',', '#');
        dictAlphabet.Add('-', '#');
        dictAlphabet.Add('?', '#');
        dictAlphabet.Add('!', '#');
        dictAlphabet.Add(' ', '#');
        Console.WriteLine("Please determine all values of the alphabet: '" + parameters[0] + "'\n");
        foreach (char c in dictAlphabet.Keys)
        {
            while (true)
            {

                if (c == ' ')
                {
                    Console.Write("spacebar = ");
                    string userImput = Console.ReadLine();
                    int i = userImput.Length;
                    if (i == 1)
                    {
                        dictAlphabet[c] = userImput[0];
                        Console.WriteLine("------");
                        break;
                    }
                    Console.WriteLine("Error: '" + userImput + "' contains no or more characters than 1");
                }
                else
                {
                    Console.Write($"{c} = ");
                    string userImput = Console.ReadLine();
                    int i = userImput.Length;
                    if (i == 1)
                    {
                        dictAlphabet[c] = userImput[0];
                        Console.WriteLine("------");
                        break;
                    }
                    Console.WriteLine("Error: '" + userImput + "' contains no or more characters than 1");
                }
            }
            
        }
        JsonSerializerOptions options = new JsonSerializerOptions {WriteIndented = true};
        string json = JsonSerializer.Serialize(dictAlphabet, options);
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string folderName = "SecretAlphabets";
        string dataName = parameters[0] + ".json";
        string folderPath = Path.Combine(currentDirectory, folderName, dataName);
        File.WriteAllText(folderPath, json);
        Console.WriteLine(parameters[0] + " was saved.");

    }
}

