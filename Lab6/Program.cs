using System;
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

                var VowelRegex = new Regex (@"^(?i)[aeiou]");
                Console.Write("\nTranslation: ");

                for (int i = 0; i < SeparateWords.Length; i++)
                {
                    if (VowelRegex.IsMatch(SeparateWords[i])) 
                    {
                        Console.Write("{0}way ", SeparateWords[i].Trim());
                    }
                    else
                    {
                        string PigLatinConsonant = ConsonantTranslation(SeparateWords[i]);
                        Console.Write(PigLatinConsonant + " ");
                    }
                }
                //Throws error if word with only consonants i.e.Gypsy, myth
                //Throws error if multiple spaces between words
                //Throws error if anything but letters are entered

                Console.WriteLine("\nWould you like to continue translating (Y/N)?");

                bool UserDecision = Decision(char.Parse(Console.ReadLine()));
            }
        }
        public static string ReadUserInput(string UserPrompt)
        {
            Console.WriteLine(UserPrompt);
            string OriginalString = Console.ReadLine();
            Match TextInput = Regex.Match(OriginalString, @"^[A-Za-z]$");
            if (TextInput.Success)
            {
                return ReadUserInput(UserPrompt);
            }
            else
            {
                return OriginalString;
            }

            //else if (OriginalString)
            //{

            //}
            //else if (OriginalString)
            //{

            //}
            //else
            //{
            //    return OriginalString;
            //}
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
                string CapString = CapLetter + RestOfWord.Substring(1) + BeginningConsonants.ToLower() + "ay";
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
