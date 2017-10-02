using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordUnscrambler.Constructors;
using WordUnscrambler.Data;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader fileReader = new FileReader();
        private static readonly WordMatcher wordMatcher = new WordMatcher();
        private const string wordListFile = "wordList.txt";
        static void Main(string[] args)
        {
            bool loopCondition = true;
            do
            {
                Console.Write("\n Please select -- F for File or M for Manual: ");
                var option = Console.ReadLine() ?? string.Empty;

                switch (option.ToUpper())
                {
                    case "F":
                        Console.Write("\n Enter scrambled words file name: ");
                        MethodToProcessFile();
                        break;
                    case "M":
                        Console.Write("\n Enter scrambled words: ");
                        MethodToProcessWords();
                        break;
                    default:
                        Console.WriteLine("\n Sorry, not recoginized");
                        break;
                }

                var getUserAnswer = string.Empty;
                do
                {
                    Console.Write("\n Would you like to continue? Y/N ");
                    getUserAnswer = (Console.ReadLine() ?? string.Empty);

                } while (
                    !getUserAnswer.Equals("Y", StringComparison.OrdinalIgnoreCase) && 
                    !getUserAnswer.Equals("N", StringComparison.OrdinalIgnoreCase));
                    loopCondition = getUserAnswer.Equals("Y", StringComparison.OrdinalIgnoreCase);
            } while (loopCondition);

        }

        private static void MethodToProcessWords()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Split(',');
            DisplayMatchedScrambledWords(scrambledWords);
        }

        private static void MethodToProcessFile()
        {
            var fileInput = Console.ReadLine() ?? string.Empty;
            string[] scrambleWordsFile = fileReader.Read(fileInput);
            DisplayMatchedScrambledWords(scrambleWordsFile);
        }

        private static void DisplayMatchedScrambledWords(string[] scrambledWords)
        {
            string[] wordlist = fileReader.Read(wordListFile);

            List<MatchedWord> matchedWords = wordMatcher.Match(scrambledWords, wordlist);

            if (matchedWords.Any())
            {
                foreach (var match in matchedWords)
                {
                    Console.WriteLine($"\n Match found {match.ScrambledWords}: {match.Word}\n");
                }
            }
            else
            {
                Console.WriteLine("\n No matches have been found.\n");
            }
        }

    }
}
