
using System.ComponentModel;

ConColor ConColor = new ConColor();
ConColor.WriteLine("\nMonoalphabeticEncryption - Version 1.0.5\n", ConsoleColor.Blue);
ConColor.WriteLine("Copyright (c) 2024 Strahlemann-lab", ConsoleColor.Blue);
string MachineName = Environment.MachineName;
ConColor.WriteLine("On Computer: " + MachineName + "\n", ConsoleColor.Blue);
string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
string folderName = "alphabets";
string folderPath = Path.Combine(currentDirectory, folderName);
if (!Directory.Exists(folderPath))
{
    Directory.CreateDirectory(folderPath);
}
CommandHandler commandHandler = new CommandHandler();
commandHandler.RegisterCommand("create", new CreateCommand());
commandHandler.RegisterCommand("delete", new DeleteCommand());
commandHandler.RegisterCommand("list", new ListCommand());
commandHandler.RegisterCommand("select", new SelectCommand());
commandHandler.RegisterCommand("encrypt", new EncryptCommand());
commandHandler.RegisterCommand("decrypt", new DecryptCommand());
commandHandler.RegisterCommand("write", new WriteTXTCommand());
commandHandler.RegisterCommand("clear", new ClearCommand());
commandHandler.RegisterCommand("help", new HelpCommand()); 
commandHandler.RegisterCommand("exit", new ExitCommand());
while (true)
{
    ConColor.Write("ME> ");
    string input = Console.ReadLine();
    commandHandler.HandleCommand(input);
}

