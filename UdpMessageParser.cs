using System;
using myApp.Models;
using Newtonsoft.Json;

namespace myApp
{
    public static class UdpMessageParser
    {
        public static bool TryParse(string udpMessage, out PosUdpMessage messageObj)
        {
            try
            {
                int bracketIndex = udpMessage.IndexOf('{');
                string secret = udpMessage.Substring(0, bracketIndex);
                string body = udpMessage.Substring(bracketIndex);

                var posUdpData = JsonConvert.DeserializeObject<PosUdpData>(body);
                messageObj = new PosUdpMessage();
                messageObj.Secret = secret;
                messageObj.PosUdpData = posUdpData;
                return true;
            }
            catch
            {
                messageObj = null;
                return false;
            }
        }
    }
}
