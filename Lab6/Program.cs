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

                string OriginalString = ReadUserInput("\nPlease enter a word:");

                string[] SeparateWords = OriginalString.ToLower().Split(' '); 

                var VowelRegex = new Regex (@"^[aeiou]");
                Console.Write("\nTranslation: ");

                for (int i = 0; i < SeparateWords.Length; i++)
                {
                    if (VowelRegex.IsMatch(SeparateWords[i])) 
                    {
                        Console.Write("{0}way ", SeparateWords[i]);
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

                Console.WriteLine("\nWould you like to translate another word (Y/N)?");

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

        public static string ConsonantTranslation(string LowerCaseString)
        {
            char[] VowelArray = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            int VowelIndex = LowerCaseString.IndexOfAny(VowelArray);

            string BeginningConsonants = LowerCaseString.Substring(0, VowelIndex);
            string RestOfWord = LowerCaseString.Substring(VowelIndex);

            string TranslatedWord = RestOfWord + BeginningConsonants + "ay";

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
