
using System.Text;

public class DecryptCommand : ICommand
{
    public ConColor ConColor = new ConColor();
    static bool AreAllCharsInDictionary(string text, Dictionary<char, char> dict)
    {
        foreach (char ch in text)
        {
            if (!dict.ContainsValue(ch))
            {
                return false;
            }
        }
        return true;
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
        ConColor.WriteLine("Text: ", ConsoleColor.DarkYellow);
        string text = null;
        while (true)
        {
            text = Console.ReadLine();
            if (text != null) { break; }
        }
        if (context.SharedDictAlphabet == null && context.SharedDictName == null)
        {
            ConColor.WriteLine("Error: no alphabet selected");
            return;
        }
        if (!AreAllCharsInDictionary(text, context.SharedDictAlphabet))
        {
            StringBuilder erorr = new StringBuilder();
            foreach (char ch in text)
            {
                string i = erorr.ToString();
                if (i.Contains(ch))
                { }
                else
                {
                    erorr.Append("'" + ch.ToString());
                }
            }
            ConColor.WriteLine($"Error: Text contains characters '{erorr}' that do not exist in the alphabet: " + context.SharedDictName, ConsoleColor.Red);
            return;
        }
        ConColor.WriteLine("Decrypted with: " + context.SharedDictName, ConsoleColor.DarkYellow);
        StringBuilder sb = new StringBuilder();

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
        ConColor.WriteLine(sb.ToString(), ConsoleColor.DarkGreen);
        context.SharedSecretText = text;


    }
}
