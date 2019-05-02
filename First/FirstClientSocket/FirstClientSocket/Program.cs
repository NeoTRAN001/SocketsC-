using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace FirstClientSocket
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

            IPEndPoint connect = new IPEndPoint(IPAddress.Parse(ipAddress), port);

            listen.Connect(connect);

            byte[] sends = new byte[100];
            String data;

            Console.WriteLine("Write a Data: ");
            data = Console.ReadLine();
            sends = Encoding.Default.GetBytes(data);

            listen.Send(sends);
            Console.ReadKey();
        }
    }
}
