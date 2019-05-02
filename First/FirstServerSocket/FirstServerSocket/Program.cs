using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace FirstServerSocket
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            String ipAddress = "127.0.0.1";
            int port = 8090;

            Socket listen = new Socket(
                  AddressFamily.InterNetwork,
                  SocketType.Stream,
                  ProtocolType.Tcp
            );

            Socket connection;
            IPEndPoint connect = new IPEndPoint(IPAddress.Parse(ipAddress), port);

            listen.Bind(connect);
            listen.Listen(5);

            connection = listen.Accept();
            Console.WriteLine("Successful connection");

            Byte[] receive = new Byte[100];
            String data = "";
            int arraySize = 0;

            arraySize = connection.Receive(receive, 0, receive.Length, 0);

            Array.Resize(ref receive, arraySize);
            data = Encoding.Default.GetString(receive);

            Console.WriteLine("Data: " + data);
            Console.ReadKey();
        }
    }
}
