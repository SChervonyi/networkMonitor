using System;
using System.Collections.Generic;
using myApp.Models;

namespace myApp
{
    public class DataStore
    {
        private static DataStore instance;

        private DataStore() { }

        public static DataStore Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataStore();
                }
                return instance;
            }
        }

        public List<PosUdpMessage> RecivedMessages { get; set; } = new List<PosUdpMessage>();

        public HashSet<string> IpRecivedDevices { get; set; } = new HashSet<string>();
    }
}
