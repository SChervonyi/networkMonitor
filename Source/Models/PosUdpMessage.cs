using System;
namespace PosNetworkMonitor.Models
{
    public class PosUdpMessage
    {
        public string Secret
        {
            get;
            set;
        }

        public string OriginalMessage
        {
            get;
            set;
        }

        public PosUdpData PosUdpData
        {
            get;
            set;
        }

        public DateTime ReceiveTime
        {
            get;
            set;
        } = DateTime.Now;
    }
}
