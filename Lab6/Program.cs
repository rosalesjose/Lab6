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
            Console.WriteLine("Pig Latin Translator");
            string OriginalString = ReadUserInput("\nPlease enter a word:");
            char [] LowerCaseStringArray = OriginalString.ToLower().ToCharArray();

            string LowerCaseString = OriginalString.ToLower();

            if ("aeiou".Contains(LowerCaseString[0]))
            {
                Console.WriteLine("\nTranslation: {0}way", LowerCaseString);
            }            
            //char[] VowelArray = {'a','e','i','o','u','A','E','I','O','U'};            

        }
        public static string ReadUserInput (string UserPrompt)
        {
            Console.WriteLine(UserPrompt);
            string OriginalString = Console.ReadLine();
            return OriginalString;
        }        
    }
}
