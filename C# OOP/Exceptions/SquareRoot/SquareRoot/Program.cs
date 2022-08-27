using System;

namespace SquareRoot
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0) {
                    throw new Exception("Invalid number.");
                
                }
                Console.WriteLine(Math.Sqrt(number));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            finally
            {
                Console.WriteLine("Goodbye.");


            }
        }
    }
}
