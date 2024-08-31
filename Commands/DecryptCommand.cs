
using System.Text;

public class DecryptCommand : ICommand
{
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
        Console.WriteLine("Text: ");
        string text = null;
        while (true)
        {
            text = Console.ReadLine();
            if (text != null) { break; }
        }
        if (context.SharedDictAlphabet == null && context.SharedDictName == null)
        {
            Console.WriteLine("Error: no alphabet selected");
            return;
        }
        if (!AreAllCharsInDictionary(text, context.SharedDictAlphabet))
        {
            Console.WriteLine("Error: Text contains characters that do not exist in the alphabet: " + context.SharedDictName);
            return;
        }
        Console.WriteLine("Decrypted with: " + context.SharedDictName);
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
        Console.WriteLine(sb);
        context.SharedSecretText = text;


    }
}
