using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace PosNetworkMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            var currentIp = Dns.GetHostAddresses(Dns.GetHostName())
                           .First(address => address.AddressFamily == AddressFamily.InterNetwork);
            var printModelBuilder = new PrintModelBuilder();

            var udp = new UDPer(currentIp, printModelBuilder);
            udp.Start();

            do
            {
                // udp.Send(GetDataSyncMessage(currentIp));
                Thread.Sleep(2000);
            }
            while (true);
        }

        private static string GetDataSyncMessage(IPAddress currentIp)
        {
            string secret = "CHES";

            return secret + "{\"meta\":{\"name\":\"CHES:f856\",\"sender\":{\"port\":12000,\"address\":\""+ currentIp.ToString() +"\"},\"channel\":\"XPOS:5a6efeffd282a5001feb665d\"}," +
                "\"payload\":{\"feed\":\"orderState\",\"count\":7,\"updateTime\":1518170048779}}";
        }
    }
}
