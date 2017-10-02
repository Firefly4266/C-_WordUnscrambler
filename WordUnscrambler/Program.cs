using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Program
    {
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
            throw new NotImplementedException();
        }

        private static void MethodToProcessFile()
        {
            throw new NotImplementedException();
        }
    }
}
