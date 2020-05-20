using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading;

namespace UDP_Async_Server
{
    class Program
    {
        private static int Port;
        private static BigInteger RequestCount;
        private static bool signal = false;

        [STAThread]
        static async void StartListener(UdpListener udpListener, IPEndPoint ıPEndPoint)
        {
         
            byte[] bytes = await udpListener.StartListener();

            signal = true;
           
            Console.WriteLine($" - From ? {ıPEndPoint}: = > {++RequestCount}");
            Console.WriteLine($"{Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");
        }
        static void ServerStarted(string[] args)
        {
            Port = args.Length > 0 ? int.Parse(args[0]) : 11000;
            Console.WindowHeight = (Console.LargestWindowHeight * 9 / 10);
            Console.WriteLine("[PORT NO:{0}]", Port);
            var IpEndPoint = new IPEndPoint(IPAddress.Any, Port);
            while (true)
            {

                StartListener(new UdpListener(new UdpClient(Port), IpEndPoint), IpEndPoint);

                while (!signal)
                    Thread.Sleep(10);

                signal = false;
            }
        }
        static void Main(string[] args)
        {
            ServerStarted(args);
        }
    }
}
