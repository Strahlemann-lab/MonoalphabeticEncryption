
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata;

public class HelpCommand : ICommand
{
    public void Execute(CommandContext context, string[] parameters)
    {
        Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
        Console.WriteLine("MonoalphabeticEncryption - Version 1.0.2");
        Console.WriteLine("Copyright (c) 2024 Strahlemann-lab");
        Console.WriteLine("");
        Console.WriteLine("General command syntax = command -argument -parameter");
        Console.WriteLine("");
        Console.WriteLine("Basic step by step instructions through the program:");
        Console.WriteLine("    - 1. Create an alphabet with command 'create -name_of_the_alphabet -optional:_number_of_fillers'.");
        Console.WriteLine("    - 2. Select the alphabet with 'select -name_of_the_alphabet'.");
        Console.WriteLine("    - 3. Encrypt or decrypt text with 'encrypt' or 'decrypt'.");
        Console.WriteLine("    - 4. Generate a text.txt with 'write -name_of_the_text'. To save the decrypted and encrypted text with\n         the solution alphabet.");
        Console.WriteLine("");
        Console.WriteLine("| command |       argument        |     parameter      |                   description                    |");
        Console.WriteLine("|---------|-----------------------|--------------------|--------------------------------------------------|");
        Console.WriteLine("| create  | -name_of_the_alphabet | /                  | Creates an alphabet.                             |");
        Console.WriteLine("| create  | -name_of_the_alphabet | -number_of_fillers | Creates an alphabet with fillers.                |");
        Console.WriteLine("| delete  | -name_of_the_alphabet | /                  | Deletes an alphabet.                             |");
        Console.WriteLine("| list    | /                     | /                  | Lists all created alphabets.                     |");
        Console.WriteLine("| list    | -name_of_the_alphabet | /                  | Lists all values of an alphabet.                 |");
        Console.WriteLine("| select  | -name_of_the_alphabet | /                  | Select an alphhelpabet.                          |");
        Console.WriteLine("| encrypt | /                     | /                  | Encrypts a text.                                 |");
        Console.WriteLine("| decrypt | /                     | /                  | Decrypts a text.                                 |");
        Console.WriteLine("| write   | -name_of_the_alphabet | /                  | Writes text with the alphabet into a 'text.txt'. |");
        Console.WriteLine("| clear   | /                     | /                  | Clears the console history.                      |");
        Console.WriteLine("| help    | /                     | /                  | Zeigt diese Informationen.                       |");
        Console.WriteLine("| exit    | /                     | /                  | Closes the program.                              |");
        Console.WriteLine("___________________________________________________________________________________________________________");
    }
}