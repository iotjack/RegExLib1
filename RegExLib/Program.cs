using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace RegExLib
{
    class Program
    {
        static void Main(string[] args)
        {
            MatchEx1();
            Console.ReadLine();
        }

        static void MatchEx1()
        {
            string file = "MatchEx1.txt";
            string[] lines = File.ReadAllLines(file);
            int total = 0;
            string pattern = @"\[(\d+)\:(\d+)\]";

            foreach (string line in lines)
            {
                var text = line.Trim();
                if (text.Length > 0)
                {
                    Console.WriteLine(line);
                    Match match = Regex.Match(text, pattern);
                    if (match.Success)
                    {
                        try
                        {
                            int cnt = int.Parse((match.Groups[1].Value)) - int.Parse((match.Groups[2].Value)) + 1;
                            total += cnt;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Matching failed; check the text pattern");
                            return;
                        }
                    }
                    else
                    {
                        total++;
                    }
                }
                
            }
            Console.WriteLine(total);
        }
    }
}
