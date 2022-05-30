using System;
using System.IO;

namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Folder\picture.jpg";
            string joinedFilePath = @"..\..\..\Folder\joined.png";
            string partOnePath = @"..\..\..\Folder\part-1.bin";
            string partTwoPath = @"..\..\..\Folder\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            FileStream source = new FileStream(sourceFilePath, FileMode.Open);
            FileStream partOne = new FileStream(partOneFilePath, FileMode.Create);
            FileStream partTwo = new FileStream(partTwoFilePath, FileMode.Create);
            double firstPartSize = Math.Ceiling(source.Length / 2.0);
            long secondPartSize = source.Length / 2;
            byte[] bufferFirst = new byte[1];
            byte[] bufferSecond = new byte[1];
            for (int i = 1; i <= firstPartSize; i++)
            {
                source.Read(bufferFirst, 0, bufferFirst.Length);
                partOne.Write(bufferFirst, 0, bufferFirst.Length);
            }

            for (int i = 1; i <= secondPartSize; i++)
            {
                source.Read(bufferSecond, 0, bufferSecond.Length);
                partOne.Write(bufferSecond, 0, bufferSecond.Length);
            }

        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            FileStream joinedFile = new FileStream(joinedFilePath, FileMode.Create);
            FileStream partOne = new FileStream(partOneFilePath, FileMode.Open);
            FileStream partTwo = new FileStream(partTwoFilePath, FileMode.Open);
            byte[] buffer = new byte[partOne.Length + partTwo.Length];
            for (int i = 0; i < partOne.Length; i++)
            {
                joinedFile.Write(partOne[i], 0, buffer.Length);
            }
            for (int i = 0; i < partTwo.Length; i++)
            {

            }
        }
    }
}

