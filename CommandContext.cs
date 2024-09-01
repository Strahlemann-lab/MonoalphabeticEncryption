public class CommandContext
{
    // gemeinsame Variablen
    public string SharedDictName { get; set; }
    public Dictionary<char, char> SharedDictAlphabet = new Dictionary<char, char>();
    public string SharedSecretText { get; set; }
}

