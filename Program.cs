using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw222
{
    internal class Program
    {
        const string CFn = "Input.txt";
        const string CRn = "Results.txt";
        static void Main(string[] args)
        {
            int nado = 0;
            string nado2 = "";
            FindWordInText(CFn, "skgsdg", out nado2, ref nado);
            Console.WriteLine(nado2);
            MoveLine(CFn, CRn, nado);
        }

        static int DifferentNumberofVowels(string s)
        {
            char[] vowels = { 'a', 'e', 'u', 'y', 'o', 'i' };
            char[] characters = s.ToCharArray();
            int numVowels = 0;
            for (int i = 0; i < characters.Length; i++)
            {
                for (int j = 0; j < vowels.Length; j++)
                {
                    if (characters[i] == vowels[j])
                    {
                        numVowels++;
                        vowels[j] = ' ';
                    }
                }
            }
            return numVowels;
        }

        static string FindWordInLine(string myLine, string dm)
        {
            string[] words = Regex.Split(myLine, "[^a-zA-Z0-9]+");
            for (int i = 0; i < words.Length; i++)
            {
                if (DifferentNumberofVowels(words[i]) == 3)
                {
                    return words[i];
                }
            }
            return "";
        }

        static void FindWordInText(string fv, string dm, out string mword, ref int mnr)
        {
            string line;
            mword = "";
            int count = 0;
            using (StreamReader reader = new StreamReader(fv))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    count++;
                    string temp = FindWordInLine(line, dm);
                    if (temp != "" && temp.Length > mword.Length)
                    {
                        mword = temp;
                        mnr = count;
                    }
                }
            }
        }

        static void MoveLine(string fvd, string fvr, int n)
        {
            string line;
            int i;
            using (StreamWriter writer = new StreamWriter(fvr))
            {
                using (StreamReader reader = new StreamReader(fvd))
                {
                    for (i = 1; i <= n; i++)
                    {
                        line = reader.ReadLine();
                        if (i == n)
                        {
                            writer.WriteLine(line);
                            break;
                        }
                    }
                }
                i = 0;
                using (StreamReader reader = new StreamReader(fvd))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        i++;
                        if (i == n)
                        {
                            continue;
                        }
                        writer.WriteLine(line);
                        
                    }
                }
            }

        }

    }
}
