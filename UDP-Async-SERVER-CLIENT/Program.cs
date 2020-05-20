using System;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading;

namespace UDP_Async_SERVER_CLIENT
{
    class Program
    {
        private static BigInteger RequestCount;
        static void Main(string[] args)
        {

        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress broadcast = IPAddress.Parse("127.0.0.1");
            while (true)
            {
                byte[] sendbuf = Encoding.ASCII.GetBytes("data");
                IPEndPoint ep = new IPEndPoint(broadcast, 11000);

                s.SendTo(sendbuf, ep);

                Console.WriteLine("Send Request = > {0}",++RequestCount);
                Thread.Sleep(100);
            }
        }
    }
}
