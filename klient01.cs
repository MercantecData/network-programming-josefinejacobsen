using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace encodingtest02
{
    class Program
    {
        static void Main(string[] args)
        {
       

            TcpClient client = new TcpClient();

            int port = 13356; // find ud af hvilken port du skal bruge?
            IPAddress ip = IPAddress.Parse("127.0.0.1"); // skiftes ud med min server ip-adresse
            IPEndPoint endPoint = new IPEndPoint(ip, port);

            client.Connect(endPoint); // forbinder sin klient-socket 
            // nu er vores client forbunder til vores server. 
            // nu skal vores program laves...

            NetworkStream stream = client.GetStream(); // sikrer at vores strøm, igennem vores socket(specifikt) 

            string text = "send a message!";
            byte[] buffer = Encoding.UTF8.GetBytes(text); // kommunikation gennem NetworkStram foregår som byte array
         
            stream.Write(buffer, 0, buffer.Length); // sender beskeden i vores buffer gennem vores system
                                                    // Stream.Write tager imod 3 parametre.
                                                    // 1. Byte array der holder den besked der skal sendes
                                                    // 2. Byte array er det første der skal sender 
                                                    // 3. Hvor mange bytes der ialt skal sendes. 


            
            string text0 = "send a new message";
            
            buffer = Encoding.UTF8.GetBytes("text0"); // jeg har slettet ("byte[]"). 

            stream.Write(buffer, 0, buffer.Length);



            client.Close(); // Vi lukker forbindelsen når beskeden er sendt






        }
    }
}
