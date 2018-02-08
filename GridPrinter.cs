using Newtonsoft.Json.Linq;

namespace myApp
{
    static class GridPrinter
    {
        public static void Print(string udpMessage)
        {
            int bracketIndex = udpMessage.IndexOf('{');
            string secret = udpMessage.Substring(0, bracketIndex);
            string body = udpMessage.Substring(bracketIndex);

            var jObject = JObject.Parse(body);
        }
    }
}