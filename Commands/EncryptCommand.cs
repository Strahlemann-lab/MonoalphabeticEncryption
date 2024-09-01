
using System.Text;

public class EncryptCommand : ICommand
{
    public ConColor ConColor = new ConColor();
    static Random rand = new Random();
    static bool AreAllCharsInDictionary(string text , Dictionary<char,char> dict)
    {
        foreach (char ch in text)
        {
            char ii = ch;
            if (char.IsUpper(ch))
            {
                ii = char.ToLower(ch);
            }
            if (!dict.ContainsKey(ii))
            {
                return false;
            }
        }
        return true;
    }
    public void Execute(CommandContext context, string[] parameters)
    {
        ConColor.WriteLine("Text: ");
        string text = null;
        while (true)
        {
            text = Console.ReadLine();
            if (text != null) { break; }
        }
        if (context.SharedDictAlphabet == null && context.SharedDictName == null)
        {
            ConColor.WriteLine("Error: No alphabet selected", ConsoleColor.Red);
            return;
        }
        if (!AreAllCharsInDictionary(text,context.SharedDictAlphabet))
        {
            StringBuilder erorr = new StringBuilder();
            foreach (char ch in text)
            {
                if (!context.SharedDictAlphabet.ContainsKey(ch))
                {
                    string i = erorr.ToString();
                    if (i.Contains(ch))
                    { }
                    else
                    {
                        erorr.Append("'" + ch.ToString());
                    }
                }
            }
            ConColor.WriteLine($"Error: Text contains characters ({erorr}) that do not exist in the alphabet: " + context.SharedDictName, ConsoleColor.Red);
            return;
        }
        ConColor.WriteLine("\nEncrypted with: " + context.SharedDictName, ConsoleColor.DarkYellow);
        StringBuilder sb = new StringBuilder();
        Dictionary<int, char> allFillerDict = new Dictionary<int, char>();
        int allFiller = 1;
        foreach (char lr in context.SharedDictAlphabet.Keys)
        {
            if (char.IsUpper(lr))
            {
                allFillerDict.Add(allFiller, context.SharedDictAlphabet.GetValueOrDefault(lr));
                allFiller++;
            }
        }
        foreach (char i in text)
        {
            char ii = i;
            if (char.IsUpper(i)) 
            {
                ii = char.ToLower(i);
            }
            char newLetter = context.SharedDictAlphabet[ii];
            sb.Append(newLetter);
            if (allFiller != 1 )
            {
                double Random10 = rand.NextDouble();
                if (Random10 < 0.4)
                {
                    int ra = rand.Next(1,allFiller);
                    sb.Append(allFillerDict[ra]);

                }
            }
        }
        ConColor.WriteLine(sb.ToString(),ConsoleColor.DarkGreen);
        context.SharedSecretText = sb.ToString();
    }
}