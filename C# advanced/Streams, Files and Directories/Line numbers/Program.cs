using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\input.txt";
            string outputPath = @"..\..\..\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using (StreamReader input = new StreamReader(inputFilePath))
            {
                using (StreamWriter output = new StreamWriter(outputFilePath))
                {
                    string line = input.ReadLine();
                    int lineCounter = 1;
                    while (line != null)
                    {
                        output.WriteLine($"{lineCounter}. {line}");
                        lineCounter++;
                        line = input.ReadLine();
                    }


                }



            }
        }
    }
}

