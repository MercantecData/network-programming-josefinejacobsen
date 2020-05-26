using System.Net.Sockets;
using System.Net;
using System.Text;
using System;

namespace server
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

            byte[] buffer = new byte[256]; // plads til at modtage en besked fra vors klient i bytes array
            // du kan selv bestemme byte("256") pladsen.

            int numberOfBytesRead = stream.Read(buffer, 0, 256); //stream.read() tager 3 parametre
            // 1. byte array som beskeden skal gemmes i.
            // 2. hvor i vore array den skal begynde at sætte de modtagne bytes ind.
            // 3. hvor mange bytes man gerne vil modtage på nuværende tidspunkt fk(256)


            string message = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead); //nu har vi decoded beskeden fra bytes

            Console.WriteLine(message); // nu printer den ud i konsollen





        }
    }
}
