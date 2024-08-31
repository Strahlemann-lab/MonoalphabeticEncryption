using System.ComponentModel;
using System.Reflection.Metadata;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class CreateCommand : ICommand
{
    public void Execute(CommandContext context, string[] parameters)
    {
        if (parameters.Length == 0)
        {
            Console.WriteLine("Error: No parameter was passed. Syntax: create -alphabetName -howManyFillers");
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
                    Console.WriteLine("System limitation: too many fillers. please smaller than 26");
                    
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: An unexpected error occurred while passing " + parameters[1].ToString() + ": " + ex.ToString());
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
                    try
                    {
                        if (dictAlphabet.ContainsValue(userImput[0]))
                        {
                            Console.WriteLine("Error: '" + userImput + "' contains an already defined character");
                        }
                        else
                        {
                            if (i == 1)
                            {
                                dictAlphabet[c] = userImput[0];
                                Console.WriteLine("------");
                                break;
                            }
                            else { Console.WriteLine("Error: '" + userImput + "' contains no or more characters than 1"); }
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
                            Console.WriteLine("Error: '" + userImput + "' contains an already defined character");
                        }
                        else
                        {
                            if (i == 1)
                            {
                                dictAlphabet[c] = userImput[0];
                                Console.WriteLine("------");
                                break;
                            }
                            else { Console.WriteLine("Error: '" + userImput + "' contains no or more characters than 1"); }
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
                            Console.WriteLine("Error: '" + userImput + "' contains an already defined character");
                        }
                        else
                        {
                            if (i == 1)
                            {
                                dictAlphabet[c] = userImput[0];
                                Console.WriteLine("------");
                                break;
                            }
                            else { Console.WriteLine("Error: '" + userImput + "' contains no or more characters than 1"); }
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
        Console.WriteLine(parameters[0] + " was saved.");

    }
}

