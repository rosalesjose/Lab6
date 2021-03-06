﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab6
{
    class Program
    {
        static bool RunApplication = true;

        static void Main(string[] args)
        {
            while (RunApplication)
            {
                Console.WriteLine("Pig Latin Translator");

                string OriginalString = ReadUserInput("\nPlease enter a phrase:");

                string[] SeparateWords = OriginalString.Split(' ');

                var VowelRegex = new Regex(@"^(?i)[aeiou]");
                var LettersRegex = new Regex(@"^[A-Za-z']+$");
                var NoVowelsRegex = new Regex(@"^[^aeiou]+$");

                Console.Write("\nTranslation: ");

                for (int i = 0; i < SeparateWords.Length; i++)
                {
                    if (!LettersRegex.IsMatch(SeparateWords[i]))
                    {
                        Console.Write(SeparateWords[i].Trim() + " ");
                    }
                    else if (VowelRegex.IsMatch(SeparateWords[i]))
                    {
                        Console.Write("{0}way ", SeparateWords[i].Trim());
                    }
                    else if (NoVowelsRegex.IsMatch(SeparateWords[i]))
                    {
                        Console.WriteLine("{0}way ", SeparateWords[i].Trim());
                    }
                    else
                    {
                        string PigLatinConsonant = ConsonantTranslation(SeparateWords[i]);
                        Console.Write(PigLatinConsonant + " ");
                    }
                }                                            
                //Won't translate words that end with punctuation             

                Console.WriteLine("\nEnter the 'Y' key to translate another word. \nOr enter in any other key to quit.");
                bool MakeDecision = true;
                while (MakeDecision)
                {
                    try
                    {
                        bool UserDecision = Decision(char.Parse(Console.ReadLine()));
                        MakeDecision = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Enter the 'Y' key if you want to run the program again.");
                        Console.WriteLine("Enter a different key if you want to exit the program.");
                    }
                }
            }
        }
        public static string ReadUserInput(string UserPrompt)
        {
            Console.WriteLine(UserPrompt);
            string OriginalString = Console.ReadLine().Trim();
            var InputRegex = new Regex(@"[\S]+$");
            if (InputRegex.IsMatch(OriginalString))
            {
                return OriginalString;
            }
            Console.Clear();
            Console.WriteLine("Pig Latin Translator");
            return ReadUserInput(UserPrompt);
        }

        public static string ConsonantTranslation(string ConsonantWord)
        {
            char[] VowelArray = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            int VowelIndex = ConsonantWord.IndexOfAny(VowelArray);

            string BeginningConsonants = ConsonantWord.Trim().Substring(0, VowelIndex);
            string RestOfWord = ConsonantWord.Trim().Substring(VowelIndex);

            var CapRegex = new Regex(@"^[A-Z]");

            if (CapRegex.IsMatch(BeginningConsonants))
            {
                string CapLetter = RestOfWord.First().ToString().ToUpper();
                string CapString = CapLetter + RestOfWord.Substring(1).ToLower() + BeginningConsonants.ToLower() + "ay";
                return CapString;
            }

            string TranslatedWord = RestOfWord + BeginningConsonants.ToLower() + "ay";

            return TranslatedWord;
        }

        public static bool Decision(char UserDecision)
        {
            if (UserDecision == 'y' || UserDecision == 'Y')
            {
                Console.Clear();
                return RunApplication = true;
            }
            else
            {
                return RunApplication = false;
            }
        }
    }
}
