﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;


//match comments, replace comments /* ... */ code  /* ... */
//must have ? (match 0 or 1 times)
//string pattern = @"\/\*.*?\*\/";
//var final_text = Regex.Replace(text, pattern, " ");


/*
Patterns I used: 
Option ticker like this  -ALK201016P12.5   ---  string pattern = @"(\w{1,4})(\d{6})(\w)(\d+(\.\d)?)";

*/
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
