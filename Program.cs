using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using Newtonsoft.Json.Linq;


namespace myApp
{

    class UDPer
    {
        private const int PORT_NUMBER = 12000;

        public const string IP = "172.17.3.146";

        Thread t = null;
        public void Start()
        {
            if (t != null)
            {
                throw new Exception("Already started, stop first");
            }
            Console.WriteLine("Started listening");
            StartListening();
        }
        public void Stop()
        {
            try
            {
                udp.Close();
                Console.WriteLine("Stopped listening");
            }
            catch { /* don't care */ }
        }

        private readonly UdpClient udp = new UdpClient(PORT_NUMBER);
        IAsyncResult ar_ = null;

        private void StartListening()
        {
            ar_ = udp.BeginReceive(Receive, new object());
        }
        private void Receive(IAsyncResult ar)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, PORT_NUMBER);
            byte[] bytes = udp.EndReceive(ar, ref ip);

            string message = Encoding.ASCII.GetString(bytes);
            if (ip.Address.ToString() != IP)
            {
                Console.WriteLine("{0} From {1} received: {2} ", DateTime.Now, ip.Address.ToString(), message);
            }
            StartListening();
        }
        public void Send(string message)
        {
            UdpClient client = new UdpClient();
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(IP), PORT_NUMBER);
            byte[] bytes = Encoding.ASCII.GetBytes(message);
            client.Send(bytes, bytes.Length, ip);
            client.Close();
            // Console.WriteLine("Sent: {0} ", message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            UDPer udp = new UDPer();
            udp.Start();
        }
    }
}



// // ConsoleKeyInfo cki;
// do
// {
//     // udp.Send("CHES!CHES!CHES!CHES!CHES!CHES!CHES!CHES!CHES!CHES!CHES!");

//     udp.Send(GetDataSyncMessage());

//     // if (Console.KeyAvailable)
//     // {
//     //     cki = Console.ReadKey(true);
//     //     switch (cki.KeyChar)
//     //     {
//     //         case 's':
//     //             udp.Send(new Random().Next().ToString());
//     //             break;
//     //         case 'x':
//     //             udp.Stop();
//     //             return;
//     //     }
//     // }
//     Thread.Sleep(2000);
// } while (true);

// private static string GetDataSyncMessage()
// {
//     string secret = "CHES";

//     return secret + "{\"meta\":{\"name\":\"XPOS:ches\",\"sender\":{\"port\":12000,\"address\":\"" + UDPer.IP + "\"},\"channel\":\"XPOS:5a705d34c0c41900120028a9\"},"
//             + "\"payload\":{\"feed\":\"timeClock\",\"count\":1,\"updateTime\":1517661934809}}\"";
// }