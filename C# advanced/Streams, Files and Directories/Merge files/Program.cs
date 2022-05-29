using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\input1.txt";
            var secondInputFilePath = @"..\..\..\input2.txt";
            var outputFilePath = @"..\..\..\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            StreamReader firstInput = new StreamReader(firstInputFilePath);
            StreamReader secondInput = new StreamReader(secondInputFilePath);
            StreamWriter output = new StreamWriter(outputFilePath, true);
            using (firstInput)
            {
                using (secondInput)
                {
                    string firstLine = firstInput.ReadLine();
                    string secondLine = secondInput.ReadLine();
                    while (firstLine != null && secondLine != null)
                    {
                        output.WriteLine(firstLine);
                        output.WriteLine(secondLine);
                        output.Flush();
                        firstLine = firstInput.ReadLine();
                        secondLine = secondInput.ReadLine();

                    }
                    if (firstLine != null)
                    {
                        while (firstLine != null)
                        {
                            output.WriteLine(firstLine);
                            output.Flush();
                            firstLine = firstInput.ReadLine();

                        }

                    }
                    else if (secondLine != null)
                    {
                        while (secondLine != null)
                        {
                            output.WriteLine(secondLine);
                            output.Flush();
                            secondLine = secondInput.ReadLine();

                        }


                    }


                }


            }
        }
    }
}

