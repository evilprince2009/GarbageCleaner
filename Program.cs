using System;
using System.IO;

namespace GarbageCleaner
{
    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Coded by Evilprince2009");
            while (true)
            {
                DirectoryInput:
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Put a directory or folder path.");
                string path = Console.ReadLine() + @"\";
                if (!Directory.Exists(path))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That's not a valid Directory !");
                    goto DirectoryInput;
                }

                ExtensionInput:

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Enter extension.");
                string extension = "*." + Console.ReadLine();

                if (extension.Length < 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter a valid extension !");
                    goto ExtensionInput;
                }


                string[] filesPath = Directory.GetFiles(path, extension, SearchOption.TopDirectoryOnly);
                int counter = filesPath.Length;

                Console.WriteLine("File(s) found with the extension " + extension.Trim('*') + " in directory:-" + counter);

                foreach (var fp in filesPath)
                {
                    FileInfo x = new (fp);
                    x.Delete();
                    Console.WriteLine("File(s) left - " + --counter);
                }

                Console.WriteLine("Start over? Type yes or no.");
                string ans = Console.ReadLine();
                if (ans == "no")
                    break;
            }
        }
    }
}
