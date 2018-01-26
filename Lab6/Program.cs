using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            bool RunApplication = true;
            while (RunApplication)
            {
                Console.WriteLine("Pig Latin Translator");

                string OriginalString = ReadUserInput("\nPlease enter a word:");
                char[] LowerCaseStringArray = OriginalString.ToLower().ToCharArray();

                string LowerCaseString = OriginalString.ToLower();

                if ("aeiou".Contains(LowerCaseString[0]))
                {
                    Console.WriteLine("\nTranslation: {0}way", LowerCaseString);
                }
                else
                {
                    string PigLatinConsonant = ConsonantTranslation(LowerCaseString);
                    Console.WriteLine("\nTranslation: {0}", PigLatinConsonant);
                }
                Console.WriteLine("\nWould you like to translate another word (Y/N)?");

                char UserDecision = char.Parse(Console.ReadLine());                

                if (UserDecision == 'y' || UserDecision == 'Y')
                {
                    RunApplication = true;
                }
                else
                {
                    RunApplication = false;
                }
            }
        }
        public static string ReadUserInput (string UserPrompt)
        {
            Console.WriteLine(UserPrompt);
            string OriginalString = Console.ReadLine();
            return OriginalString;
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

        
    }
}
