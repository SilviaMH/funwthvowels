using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace funwthvowels
{

    class Result
    {
        public static int lenghtLongestSubsequence(string s)
       {
            int lenghtMax = 0;
            int auxLenght = 0;
            char prevVowel = '\0';
            List<char> vowels = new List<char>(new char[] { 'a', 'e', 'i', 'o', 'u' });

            for(int i=0; i<s.Count(); i++)
            {
                if(s[i]=='u')
                {
                    if(i == s.Count() -1)
                    {
                        if (lenghtMax < auxLenght)
                        {
                            lenghtMax = auxLenght;
                        }
                    }
                }
                else
                {
                    if (prevVowel == 'u')
                    {
                        if (lenghtMax < auxLenght)
                        {
                            lenghtMax = auxLenght;
                        }

                        auxLenght = 0;
                        prevVowel = '\0';
                    }
                }

                if (auxLenght == 0)
                {
                    if (s[i] == 'a')
                    {
                        auxLenght += 1;
                        prevVowel = s[i];
                    }
                }
                else if (prevVowel == s[i])
                {
                    auxLenght += 1;
                }
                else if (s[i]!=prevVowel)
                {
                    if (s[i] == vowels[vowels.IndexOf(prevVowel) + 1])
                    {
                        auxLenght += 1;
                        prevVowel = s[i];
                    }
                    else
                    {
                        auxLenght = 0;
                        prevVowel = '\0';
                    }
                }
                else
                {
                    //IDK what to do lol
                }
            }

            return lenghtMax;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int t = Convert.ToInt32(Console.ReadLine().Trim());

            for (int tItr = 0; tItr < t; tItr++)
            {
                string s = Console.ReadLine();

                int result = Result.lenghtLongestSubsequence(s);

                Console.WriteLine(result);
            }

            Console.ReadKey();
            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
