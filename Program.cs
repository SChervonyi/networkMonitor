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
                udp.Send(GetDataSyncMessage(currentIp));
                Thread.Sleep(2000);
            }
            while (true);
        }

        private static string GetDataSyncMessage(IPAddress currentIp)
        {
            string secret = "CHES";

            return secret + "{\"meta\":{\"name\":\"XPOS:ches\",\"sender\":{\"port\":12000,\"address\":\"" + currentIp.ToString() + "\"},\"channel\":\"XPOS:5a705d34c0c41900120028a9\"},"
                    + "\"payload\":{\"feed\":\"timeClock\",\"count\":1,\"updateTime\":1517661934809}}\"";
        }
    }
}
