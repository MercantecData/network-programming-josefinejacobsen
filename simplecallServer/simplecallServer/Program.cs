using System.Net.Sockets;
using System.Net;
using System.Text;
using System;

namespace simplecallServer
{
    class Program
    {
        static void Main(string[] args)
        {


            int port = 13356; // find ip-adressen vores server skal lytte fra.-klienten
            IPAddress ip = IPAddress.Any; //.Any er så vi kan lytte på alle indkomne forbindelser
            IPEndPoint localEndpoint = new IPEndPoint(ip, port);

            TcpListener listener = new TcpListener(localEndpoint); // listen som vores server socket som klienten kan forbind til
            listener.Start(); //start() igang sætter med at lytte indkomne bedskeder.


            // nu skal vi have serveren til at acceptere vores klient
            Console.WriteLine("Awaiting Clients");
            TcpClient client = listener.AcceptTcpClient(); // 


            // nu har vi i serven 2 sockets der arbejder.
            // 1. (TcpListener) sin egen lokale socket i vores listener objekt
            // 2. (TcpClient) en remote socket i vores clinent objekt



            NetworkStream stream = client.GetStream(); //begynde at sende og modtage beskeder.
                                                       // network stream objekt
            string text = "nej";
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            stream.Write(buffer, 0, buffer.Length); 


           

            client.Close();
            


        }
    }
}
