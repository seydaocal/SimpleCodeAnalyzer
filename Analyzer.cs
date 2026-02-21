using System;
using System.IO;
using System.Collections.Generic;

class Analyzer
{
    public void Analyze(string[] files)
    {
        int totalLines = 0;
        int commentLines = 0;

        Dictionary<string, int> keywords = new Dictionary<string, int>();
        keywords["if"] = 0;
        keywords["for"] = 0;
        keywords["while"] = 0;

        foreach (string file in files)
        {
            Console.WriteLine("\nBeing analyzing: " + file);
            string[] lines = File.ReadAllLines(file); // read the all line in the file.
            foreach (string line in lines)
            {
                string trimmed = line.Trim();
                if (trimmed != "") //skip the empty lines.
                {
                    totalLines++;

                    if (trimmed.StartsWith("//")) //count the number of comment lines.
                    {
                        commentLines++;
                    }
                    foreach (var key in keywords.Keys)//count the each keyword in the code.
                    {
                        if (line.Contains(key))
                        {
                            keywords[key]++;
                        }
                    }
                }
            }
        }
        Console.WriteLine("\nTotal lines of code: " + totalLines);
        Console.WriteLine("\nTotal comment lines of code: " + commentLines);
        foreach (var pair in keywords)
        {
            Console.WriteLine("Numbers of " + pair.Key + " : " + pair.Value);
        }
    }
}
