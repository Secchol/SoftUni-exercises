using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\words.txt";
            string textPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (StreamReader wordsFile = new StreamReader(wordsFilePath))
            {
                var wordsCount = new Dictionary<string, int>();
                string[] words = wordsFile.ReadLine().Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    wordsCount[word] = 0;

                }



            }
        }
    }
}

