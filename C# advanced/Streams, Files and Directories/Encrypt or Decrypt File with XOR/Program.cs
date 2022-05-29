using System;
using System.IO;

namespace Encrypt_or_Decrypt_File_with_XOR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var pic = new FileStream("../../../NewFolder/picture.jpg",FileMode.Open))
            {
                using (var encPic = new FileStream("../../../example-encrypted.jpg", FileMode.Create))
                {
                    byte[] buffer = new byte[1024];
                    while (true)
                    {
                        int bytesRead = pic.Read(buffer);
                        if (bytesRead == 0) break;
                        const byte secret = 183;
                        for (int i = 0; i < bytesRead; i++)
                            buffer[i] = (byte)(buffer[i] ^ secret);
                        encPic.Write(buffer, 0, bytesRead);
                    }
                }
            }

        }
    }
}
