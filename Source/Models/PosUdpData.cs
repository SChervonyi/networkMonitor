using System;
namespace myApp.Models
{
    public class PosUdpData
    {
        public PosUdpData()
        {
        }

        public Meta Meta
        {
            get;
            set;
        }

        public Payload Payload
        {
            get;
            set;
        }
    }
}
