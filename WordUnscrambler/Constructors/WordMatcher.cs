using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordUnscrambler.Data;

namespace WordUnscrambler.Constructors
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            var matchedWords = new List<MatchedWord>();
            foreach (var scramWord in scrambledWords)
            {
                foreach (var word in wordList)
                {
                    if (scramWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(BuildMatchedWord(scramWord, word));
                    }
                    else
                    {
                        var scramWordArray = scramWord.ToCharArray();
                        var wordArray = word.ToCharArray();

                        Array.Sort(scramWordArray);
                        Array.Sort(wordArray);

                        var sortedScram = scramWordArray.ToString();
                        var sortedWord = wordArray.ToString();
                        if (sortedScram.Equals(sortedWord, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(BuildMatchedWord(scramWord, word));
                        }
                    }
                }
            }

            return matchedWords;
        }
        private MatchedWord BuildMatchedWord(string scramWord, string word)
        {
            MatchedWord matchedWord = new MatchedWord
            {
                ScrambledWords = scramWord,
                Word = word
            };
            return matchedWord;
        }
    }
}
