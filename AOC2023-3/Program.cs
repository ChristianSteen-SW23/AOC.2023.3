using System;
using System.IO;

namespace AOC20233
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "datafile.txt";

            string[] lines = ReadFile(filePath);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }


            foreach (string line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    switch (line[i])
                    {
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                        case '7':
                        case '8':
                        case '9':
                        case '.':
                            break;
                        default:
                            Console.Write(line[i] + " ");
                            break;
                    }
                }
                Console.WriteLine();
            }



            Console.ReadLine();
        }
        static string[] ReadFile(string filePath)
        {
            try
            {
                int lineCount = 0;
                // Finds the amount of lines in a the data file
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (sr.ReadLine() != null)
                    {
                        lineCount++;
                    }
                }

                Console.WriteLine("Line count is: " + lineCount);

                using (StreamReader sr = new StreamReader(filePath))
                {
                    // Sets up the array to storge the data
                    string[] lines = new string[lineCount];

                    // Makes a forloop to scan in all the data
                    for (int i = 0; i < lineCount; i++)
                    {
                        lines[i] = sr.ReadLine();
                    }
                    /*foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }*/
                    return lines;
                }
                
            }
            catch
            {
                Console.WriteLine("Did not find the file");
                Environment.Exit(-1);
                return null;
            }
        }
    }
}