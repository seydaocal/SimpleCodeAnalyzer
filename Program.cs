using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the folder path: ");
        string path = Console.ReadLine();

        while (!Directory.Exists(path))
        {
            Console.WriteLine("There is no such a folder! Try again: ");
            path = Console.ReadLine();
        } // check that there is any folder.
        
        Console.WriteLine("The folder is found!");

        string[] files = Directory.GetFiles(path, "*.cs"); //get the cs files in the folder.
        
        Console.WriteLine("\nFound cs files:");
        
        Analyzer analyzer = new Analyzer();
        analyzer.Analyze(files);
    }
}