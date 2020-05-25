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

          
            
            text = Encoding.ASCII.GetString(bytes);
            Console.WriteLine(text);
        }
    }
}
