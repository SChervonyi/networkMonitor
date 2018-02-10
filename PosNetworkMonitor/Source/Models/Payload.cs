using System;
namespace PosNetworkMonitor.Models
{
    public class Payload
    {
        public string Feed
        {
            get;
            set;
        }

        public int Count
        {
            get;
            set;
        }

        public long UpdateTime
        {
            get;
            set;
        }
    }
}
