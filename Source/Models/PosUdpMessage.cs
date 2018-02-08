using System;
namespace myApp.Models
{
    public class PosUdpMessage
    {
        public string Secret 
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
        }
    }
}
