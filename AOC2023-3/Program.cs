using System;
using System.IO;

namespace AOC20233
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "datafilebig.txt";

            string[] lines = ReadFile(filePath);

            int counterPart1 = 0;
            for (int lineC = 0; lineC  < lines.Length; lineC ++)
            {
                Console.WriteLine(lines[lineC]);
                for (int index = 0; index < lines[lineC].Length; index++)
                {
                    //Console.WriteLine(lineC+" "+index);
                    if (!CheckForSpecialChar(lines[lineC][index])) continue;

                    if (CheckForNumberChar(lines[lineC-1][index]))
                    {
                        counterPart1 += Convert.ToInt32(FindNumberFromChar(lines, lineC - 1, index));
                    } else
                    {
                        counterPart1 += Convert.ToInt32(FindNumberFromChar(lines, lineC - 1, index-1));
                        counterPart1 += Convert.ToInt32(FindNumberFromChar(lines, lineC - 1, index+1));
                    }

                    if (CheckForNumberChar(lines[lineC + 1][index]))
                    {
                        counterPart1 += Convert.ToInt32(FindNumberFromChar(lines, lineC + 1, index));
                    }
                    else
                    {
                        counterPart1 += Convert.ToInt32(FindNumberFromChar(lines, lineC + 1, index - 1));
                        counterPart1 += Convert.ToInt32(FindNumberFromChar(lines, lineC + 1, index + 1));
                    }

                    if (CheckForNumberChar(lines[lineC][index - 1])){
                        counterPart1 += Convert.ToInt32(FindNumberFromChar(lines, lineC, index-1));
                    }
                    if (CheckForNumberChar(lines[lineC][index + 1]))
                    {
                        counterPart1 += Convert.ToInt32(FindNumberFromChar(lines, lineC, index + 1));
                    }
                    //string number = FindNumberFromChar(lines, lineC - 1, index - 1);
                    //Console.WriteLine(number);
                    //Console.Write(lines[lineC][index]);
                }
            }
            Console.WriteLine("Part one answer "+counterPart1);

            int counterPart2 = 0;
            int counterPart3 = 0;
            for (int lineC = 0; lineC < lines.Length; lineC++)
            {
                for (int index = 0; index < lines[lineC].Length; index++)
                {

                    if (!CheckForGear(lines[lineC][index])) continue;
                    //Console.WriteLine(counterPart2);
                    int[] num= { 0, 0, 0, 0, 0, 0, 0, 0};
                    if (CheckForNumberChar(lines[lineC - 1][index]))
                    {
                        num[0] = Convert.ToInt32(FindNumberFromChar(lines, lineC - 1, index));
                    }
                    else
                    {
                        num[1] = Convert.ToInt32(FindNumberFromChar(lines, lineC - 1, index - 1));
                        num[2] = Convert.ToInt32(FindNumberFromChar(lines, lineC - 1, index + 1));
                    }

                    if (CheckForNumberChar(lines[lineC + 1][index]))
                    {
                        num[3] = Convert.ToInt32(FindNumberFromChar(lines, lineC + 1, index));
                    }
                    else
                    {
                        num[4] = Convert.ToInt32(FindNumberFromChar(lines, lineC + 1, index - 1));
                        num[5] = Convert.ToInt32(FindNumberFromChar(lines, lineC + 1, index + 1));
                    }

                    if (CheckForNumberChar(lines[lineC][index - 1]))
                    {
                        num[6] = Convert.ToInt32(FindNumberFromChar(lines, lineC, index - 1));
                    }
                    if (CheckForNumberChar(lines[lineC][index + 1]))
                    {
                        num[7] = Convert.ToInt32(FindNumberFromChar(lines, lineC, index + 1));
                    }
                    int counter = 1;
                    int counterAmount = 0;
                    for (int i = 0; i < 8; i++) 
                    {
                        if (num[i] != 0)
                        {
                            
                            counterAmount++;
                            counter *= num[i];
                        }
                    }
                    
                    
                    if (counterAmount == 2)
                    {
                        counterPart3++;
                        counterPart2 += counter;
                    }
                    //string number = FindNumberFromChar(lines, lineC - 1, index - 1);
                    //Console.WriteLine(number);
                    //Console.Write(lines[lineC][index]);
                }
            }
            Console.WriteLine("Part two answer " + counterPart2+" "+counterPart3);

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

        static bool CheckForSpecialChar(char ch)
        {
            switch (ch)
            {
                case '0':
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
                    return false;
                    break;
                default:
                    return true;
                    break;
            }
        }
        static bool CheckForNumberChar(char ch)
        {
            switch (ch)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    return true;
                    break;
                default:
                    return false;
                    break;
            }
        }
        static bool CheckForGear(char ch)
        {
            switch (ch)
            {
                case '*':
                    return true;
                    break;
                default:
                    return false;
                    break;
            }
        }

        static string FindNumberFromChar(string[] lines, int line, int ch)
        {
            if (!CheckForNumberChar(lines[line][ch])) return "0";

            int leftCount = 0;
            for (int h = 0; ch - h >= 0 && ch + h <= 139 && CheckForNumberChar(lines[line][ch - h]); h++)
            {
                leftCount = h;
            }

            int rightCount = 0;
            for (int h = 0; ch - h >= 0 && ch + h <= 139 && CheckForNumberChar(lines[line][ch + h]); h++)
            {
                rightCount = h;
            }

            string number = lines[line][ch].ToString();
            for (int h = 1; h < leftCount + 1; h++)
            {
                number = string.Concat(lines[line][ch - h].ToString(), number);
            }
            for (int h = 1; h < rightCount + 1; h++)
            {
                number = string.Concat(number, lines[line][ch + h].ToString());
            }

            return number;
        }
    }
}