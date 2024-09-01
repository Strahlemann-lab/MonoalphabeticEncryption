using System.ComponentModel;
using System.Reflection.Metadata;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class CreateCommand : ICommand
{
    public ConColor ConColor = new ConColor();
    public void Execute(CommandContext context, string[] parameters)
    {
        if (parameters.Length == 0)
        {
            ConColor.WriteLine("Error: No parameter was passed. Syntax: create -alphabetName -howManyFillers", ConsoleColor.Red);
            return;
        }
        int? howManyFillers = null;
        if (parameters.Length >= 2)
        {
            try
            {
                while(true)
                {
                    howManyFillers = int.Parse(parameters[1]);
                    if (howManyFillers < 26) { break; }
                    ConColor.WriteLine("System limitation: too many fillers. please smaller than 26", ConsoleColor.Red);
                    
                }
                
            }
            catch (Exception ex)
            {
                ConColor.WriteLine("Error: An unexpected error occurred while passing " + parameters[1].ToString() + ": " + ex.ToString(), ConsoleColor.Red);
                return;
            }
            
        }

        Dictionary<char, char> dictAlphabet = new Dictionary<char, char>();
        for (char c = 'a'; c <= 'z'; c++)
        {
            dictAlphabet.Add(c, '#');
        }
        dictAlphabet.Add('ä', '#');
        dictAlphabet.Add('ü', '#');
        dictAlphabet.Add('ö', '#');
        dictAlphabet.Add('ß', '#');
        dictAlphabet.Add('.', '#');
        dictAlphabet.Add(',', '#');
        dictAlphabet.Add('-', '#');
        dictAlphabet.Add('?', '#');
        dictAlphabet.Add('!', '#');
        dictAlphabet.Add(' ', '#');
        if (howManyFillers != null)
        {
            char c = 'A';
            for (int i = 1; i <= howManyFillers; i++)
            {
                dictAlphabet.Add(c,'#');
                c++;
            }
        }
        ConColor.WriteLine("Please determine all values of the alphabet: '" + parameters[0] + "'\n", ConsoleColor.DarkYellow);
        foreach (char c in dictAlphabet.Keys)
        {
            while (true)
            {

                if (c == ' ')
                {
                    Console.Write("spacebar = ");
                    string userImput = Console.ReadLine();
                    int i = userImput.Length;
                    try
                    {
                        if (dictAlphabet.ContainsValue(userImput[0]))
                        {
                            ConColor.WriteLine("Error: '" + userImput + "' contains an already defined character", ConsoleColor.Red);
                        }
                        else
                        {
                            if (i == 1)
                            {
                                dictAlphabet[c] = userImput[0];
                                Console.WriteLine("------");
                                break;
                            }
                            else { ConColor.WriteLine("Error: '" + userImput + "' contains no or more characters than 1", ConsoleColor.Red); }
                        }
                    }
                    catch (Exception ex) { }
                }
                if(char.IsUpper(c))
                {
                    Console.Write("filler = ");
                    string userImput = Console.ReadLine();
                    int i = userImput.Length;
                    try
                    {
                        if (dictAlphabet.ContainsValue(userImput[0]))
                        {
                            ConColor.WriteLine("Error: '" + userImput + "' contains an already defined character", ConsoleColor.Red);
                        }
                        else
                        {
                            if (i == 1)
                            {
                                dictAlphabet[c] = userImput[0];
                                Console.WriteLine("------");
                                break;
                            }
                            else { ConColor.WriteLine("Error: '" + userImput + "' contains no or more characters than 1", ConsoleColor.Red); }
                        }
                    }
                    catch (Exception ex) { }
                }
                else
                {
                    Console.Write($"{c} = ");
                    string userImput = Console.ReadLine();
                    int i = userImput.Length;
                    try
                    {
                        if (dictAlphabet.ContainsValue(userImput[0]))
                        {
                            ConColor.WriteLine("Error: '" + userImput + "' contains an already defined character", ConsoleColor.Red);
                        }
                        else
                        {
                            if (i == 1)
                            {
                                dictAlphabet[c] = userImput[0];
                                Console.WriteLine("------");
                                break;
                            }
                            else { ConColor.WriteLine("Error: '" + userImput + "' contains no or more characters than 1", ConsoleColor.Red); }
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            
        }
        JsonSerializerOptions options = new JsonSerializerOptions {WriteIndented = true};
        string json = JsonSerializer.Serialize(dictAlphabet, options);
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string folderName = "alphabets";
        string dataName = parameters[0] + ".json";
        string folderPath = Path.Combine(currentDirectory, folderName, dataName);
        File.WriteAllText(folderPath, json);
        ConColor.WriteLine($"'{parameters[0]}' was saved.", ConsoleColor.DarkGreen);

    }
}
