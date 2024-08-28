using System.IO.Enumeration;
using static System.Net.Mime.MediaTypeNames;

public class ListCommand : ICommand
{
    public void Execute(CommandContext context, string[] parameters)
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string folderName = "Alphabets";
        string folder = Path.Combine(currentDirectory, folderName);
        if (Directory.Exists(folder))
        {
            string[] fileName = Directory.GetFiles(folder);
            string klickbarerLink = $"{folder.Replace(@"\", "/")}";
            Console.WriteLine("Link for the folder.\n" + klickbarerLink + "\n");
            if (fileName == null || fileName.Length == 0) { Console.WriteLine("No alphabets available."); return; }
            Console.WriteLine(string.Format("| {0, -30} | {1, -30} |", "alphabet", "file name"));
            Console.WriteLine("|--------------------------------|--------------------------------|");
            foreach (string i in fileName)
            {
                string ii = i.Replace(folder,"");
                ii = ii.Remove(0,1);
                string alphabet = ii;
                alphabet = alphabet.Replace(".json", "");
                Console.WriteLine(string.Format("| {0, -30} | {1, -30} |", alphabet, ii));
            }
        }
        else { Console.WriteLine("Error: No save folder exists! Please restart the program."); return; }
    }
}

