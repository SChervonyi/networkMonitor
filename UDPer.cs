using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using myApp.Models;


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
            if (UdpMessageParser.TryParse(message, out PosUdpMessage messageObj))
            {
                DataStore.Instance.RecivedMessages.Add(messageObj);
                var messageGrid = PrintModelBuilder.BuildPringModelGrid(DataStore.Instance.RecivedMessages);
                GridPrinter.Print(messageGrid);
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
}
