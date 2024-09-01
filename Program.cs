
using System.ComponentModel;

Console.WriteLine("\nMonoalphabeticEncryption - Version 1.0.4\n");
Console.WriteLine("Copyright (c) 2024 Strahlemann-lab");
string MachineName = Environment.MachineName;
Console.WriteLine("On Computer: " + MachineName + "\n");

string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
string folderName = "alphabets";
string folderPath = Path.Combine(currentDirectory, folderName);
if (!Directory.Exists(folderPath))
{
    Directory.CreateDirectory(folderPath);
}

CommandHandler commandHandler = new CommandHandler();

// Commands registrieren
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

// Schleife zum Eingeben von Befehlen
while (true)
{
    Console.Write("ME> ");
    string input = Console.ReadLine();
    commandHandler.HandleCommand(input);
}

 