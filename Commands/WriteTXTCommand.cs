using System.Text;
using static System.Net.Mime.MediaTypeNames;

public class WriteTXTCommand : ICommand
{
    static string lineBreak(string text, int charactersProLine)
    {
        StringBuilder ergebnis = new StringBuilder();
        StringReader reader = new StringReader(text);
        string currentLine;
        string restLine = "";
        while ((currentLine = reader.ReadLine()) != null)
        {
            currentLine = restLine + currentLine;
            restLine = "";

            while (currentLine.Length > charactersProLine)
            {
                int lastSpaceIndex = currentLine.LastIndexOf(' ', charactersProLine);
                if (lastSpaceIndex == -1)
                {
                    ergebnis.AppendLine(currentLine.Substring(0, charactersProLine));
                    currentLine = currentLine.Substring(charactersProLine);
                }
                else
                {
                    ergebnis.AppendLine(currentLine.Substring(0, lastSpaceIndex));
                    currentLine = currentLine.Substring(lastSpaceIndex + 1);
                }
            }
            restLine = currentLine;
        }
        if (restLine.Length > 0)
        {
            ergebnis.AppendLine(restLine);
        }

        return ergebnis.ToString();
    }
    static char FindKeyByValue(Dictionary<char, char> dict, char value)
    {
        foreach (var kvp in dict)
        {
            if (kvp.Value == value)
            {
                return kvp.Key;
            }
        }
        return 'x';
    }
    public void Execute(CommandContext context, string[] parameters)
    {
        if (parameters.Length == 0)
        {
            Console.WriteLine("Error: No parameter was passed. Syntax: write -fileName");
            return;
        }
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string folderName = "printed-alphabet";
        string folder = Path.Combine(currentDirectory, folderName);
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }
        string dataName = Path.Combine(folder, parameters[0] + ".txt");

        //table generator for alphabet
        StringBuilder dict = new StringBuilder();
        if (context.SharedDictAlphabet == null) { Console.WriteLine("Error: no alphabet selected"); return; };

        dict.AppendLine(">>>  Secret alphabet: " + parameters[0] + "  <<<");
        dict.AppendLine("");
        dict.AppendLine(string.Format("   | {0, -5} | {1, -5} |", "Key", "Value"));
        dict.AppendLine("   |-------|-------|");
        foreach(var i in context.SharedDictAlphabet)
        {
            dict.AppendLine(string.Format("   | {0, -5} | {1, -5} |", i.Key, i.Value));
        }
        dict.AppendLine("\n");

        // plain text 
        dict.AppendLine(">>>  plain text  <<<");
        dict.AppendLine("");
        StringBuilder sb = new StringBuilder();
        string text = context.SharedSecretText;
        foreach (char i in text)
        {
            char kk = i;
            char newLetter = FindKeyByValue(context.SharedDictAlphabet, kk);
            if (char.IsUpper(newLetter))
            {
            }
            else
            {
                sb.Append(newLetter);
            }
        }
        dict.AppendLine(lineBreak(sb.ToString(), 105));
        dict.AppendLine("\n");

        // Secret text
        dict.AppendLine(">>>  Secret text  <<<");
        dict.AppendLine("");
        dict.AppendLine(lineBreak(context.SharedSecretText, 105));

        string ii = dataName.Replace(folder, "");
        ii = ii.Remove(0, 1);
        try
        {
            File.WriteAllText(dataName, dict.ToString());
            Console.WriteLine($"{ii} was created successfully");
            Console.WriteLine(folder);
        }
        catch (Exception ex)
        {
            
            Console.WriteLine($"Error: An error occurred while generating the {ii}.   {ex.Message}");
        }


    }
}
