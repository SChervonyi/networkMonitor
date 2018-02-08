using System;
using System.Threading;

namespace myApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            UDPer udp = new UDPer();
            udp.Start();

            do
            {
                udp.Send(GetDataSyncMessage());
                Thread.Sleep(2000);
            }
            while (true);
        }

        private static string GetDataSyncMessage()
        {
            string secret = "CHES";

            return secret + "{\"meta\":{\"name\":\"XPOS:ches\",\"sender\":{\"port\":12000,\"address\":\"" + UDPer.IP + "\"},\"channel\":\"XPOS:5a705d34c0c41900120028a9\"},"
                    + "\"payload\":{\"feed\":\"timeClock\",\"count\":1,\"updateTime\":1517661934809}}\"";
        }
    }
}
