using System;

namespace PosNetworkMonitor.Models
{
    public class PrintModel
    {
        public string DataSyncName
        {
            get;
            set;
        }

        public string Ip
        {
            get;
            set;
        }

        public int MessageCount
        {
            get;
            set;
        }

        public double TimeDiff
        {
            get;
            set;
        } = -1;

        public string Message
        {
            get;
            set;
        }

        public DateTime Time
        {
            get;
            set;
        }
    }
}
