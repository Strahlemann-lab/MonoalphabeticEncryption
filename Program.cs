
Console.WriteLine("\nMonoalphabeticEncryption - Version 1.0.2\n");
Console.WriteLine("Copyright (c) 2024 Strahlemann-lab");
string MachineName = Environment.MachineName;
Console.WriteLine("On Computer: " + MachineName + "\n");

string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
string folderName = "SecretAlphabets";
string folderPath = Path.Combine(currentDirectory, folderName);
if (!Directory.Exists(folderPath))
{
    Directory.CreateDirectory(folderPath);
}

CommandHandler commandHandler = new CommandHandler();

// Commands registrieren
commandHandler.RegisterCommand("create", new CreateCommand());
commandHandler.RegisterCommand("delete", new DeleteCommand());
commandHandler.RegisterCommand("list", new ExitCommand()); // Fehlend
commandHandler.RegisterCommand("select", new ExitCommand()); // Fehlend
commandHandler.RegisterCommand("encode", new ExitCommand()); // Fehlend
commandHandler.RegisterCommand("decode", new ExitCommand()); // Fehlend
commandHandler.RegisterCommand("write.txt", new ExitCommand()); // Fehlend
commandHandler.RegisterCommand("clear", new ClearCommand());
commandHandler.RegisterCommand("help", new ExitCommand()); // Fehlend
commandHandler.RegisterCommand("exit", new ExitCommand());

// Schleife zum Eingeben von Befehlen
while (true)
{
    Console.Write("ME> ");
    string input = Console.ReadLine();
    commandHandler.HandleCommand(input);
}
