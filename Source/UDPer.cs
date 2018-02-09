using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using myApp.Models;
using System.Collections.Generic;

namespace myApp
{
    public class UDPer
    {
        private const int PORT_NUMBER = 12000;

        private readonly IPAddress currentIp;

        private readonly UdpClient udp = new UdpClient(PORT_NUMBER);

        private readonly PrintModelBuilder printModelBuilder;

        private readonly List<PosUdpMessage> receivedMessages = new List<PosUdpMessage>();

        private IAsyncResult ar_ = null;

        private Thread t = null;

        public UDPer(IPAddress currentIp, PrintModelBuilder printModelBuilder)
        {
            this.currentIp = currentIp;
            this.printModelBuilder = printModelBuilder;
        }

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

        public void Send(string message)
        {
            UdpClient client = new UdpClient();
            IPEndPoint ip = new IPEndPoint(currentIp, PORT_NUMBER);
            byte[] bytes = Encoding.ASCII.GetBytes(message);
            client.Send(bytes, bytes.Length, ip);
            client.Close();
            // Console.WriteLine("Sent: {0} ", message);
        }

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
                receivedMessages.Add(messageObj);
                var messageGrid = printModelBuilder.BuildPrintModelGrid(receivedMessages);
                GridPrinter.Print(messageGrid);
            }
            StartListening();
        }
    }
}
