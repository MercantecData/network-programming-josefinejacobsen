using System;
using System.Text;

namespace EncodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "jeg håber du er glad";
            byte[] bytes = Encoding.ASCII.GetBytes(text);

            foreach(byte b in bytes)
            {
                Console.WriteLine(b);
            }
            
        }
    }
}
