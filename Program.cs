
Console.WriteLine("\nMonoalphabeticEncryption - Version 1.0.2\n");
Console.WriteLine("Copyright (c) 2024 Strahlemann-lab");
string MachineName = Environment.MachineName;
Console.WriteLine("On Computer: " + MachineName + "\n");

CommandHandler commandHandler = new CommandHandler();

// Commands registrieren
commandHandler.RegisterCommand("exit", new ExitCommand());

// Schleife zum Eingeben von Befehlen
while (true)
{
    Console.Write("ME> ");
    string input = Console.ReadLine();
    commandHandler.HandleCommand(input);
}
