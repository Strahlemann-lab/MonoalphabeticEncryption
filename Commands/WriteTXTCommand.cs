public class WriteTXTCommand : ICommand
{
    public void Execute(CommandContext context, string[] parameters)
    {
        foreach(var i in context.SharedDictAlphabet)
        {
            Console.WriteLine(i.Key + " : " + i.Value);
        }
    }
}