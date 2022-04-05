using System;
using System.Linq;

namespace Kamino_factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string DNAAsText = Console.ReadLine();
            int sumMax = int.MinValue;
            int seqlengthMax = int.MinValue;
            int startindexMax = int.MinValue;
            int linesMax = int.MinValue;
            int lines = 1;
            int[] bestsequance = new int[length];
            while (DNAAsText != "Clone them!")
            {
                int sum = 0;
                int seqLength = 0;
                int startIndex = 0;
                int temp = 0;
                int[] dnasequance = DNAAsText
                    .Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int i = 0; i < dnasequance.Length; i++)
                {



                    for (int j = i; j < dnasequance.Length - 1; j++)
                    {

                        if (dnasequance[j] == 1 && dnasequance[j] == dnasequance[j + 1])
                        {
                            seqLength++;
                            temp++;
                            if (temp == 1)
                            {
                                startIndex = j;

                            }


                        }
                        else
                        {
                            break;

                        }
                    }
                }
                for (int i = 0; i < dnasequance.Length; i++)
                {
                    sum += dnasequance[i];
                }

                if (seqLength > seqlengthMax)
                {
                    linesMax = lines;
                    bestsequance = dnasequance;
                    sumMax = sum;
                    startindexMax = startIndex;
                    seqlengthMax = seqLength;

                }
                else if (seqLength == seqlengthMax && startIndex < startindexMax)
                {
                    linesMax = lines;
                    bestsequance = dnasequance;
                    sumMax = sum;
                    startindexMax = startIndex;
                    seqlengthMax = seqLength;

                }
                else if (seqLength == seqlengthMax && startIndex == startindexMax && sum > sumMax)
                {
                    linesMax = lines;
                    bestsequance = dnasequance;
                    sumMax = sum;
                    startindexMax = startIndex;
                    seqlengthMax = seqLength;

                }
                lines++;
                DNAAsText = Console.ReadLine();




            }
            Console.WriteLine($"Best DNA sample {linesMax} with sum: {sumMax}.");
            Console.WriteLine(String.Join(" ", bestsequance));



        }
    }
}

