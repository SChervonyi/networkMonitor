using System;
using System.Collections.Generic;
using System.Linq;
using myApp.Models;

namespace myApp
{
    public static class PrintModelBuilder
    {
        public static List<PrintModel> BuildPrintModelGrid(List<PosUdpMessage> messageStore)
        {
            var result = new List<PrintModel>();
            var groupByIp = messageStore.GroupBy(x => x.PosUdpData.Meta.Sender.Address);
            foreach (var item in groupByIp)
            {
                result.Add(BuildPrintModel(item));
            }
            return result;
        }

        private static PrintModel BuildPrintModel(IEnumerable<PosUdpMessage> messageStore)
        {
            var result = new PrintModel();
            var orderedMessages = messageStore.OrderBy(x => x.ReceiveTime);
            var lastData = orderedMessages.Last();

            var itemCount = orderedMessages.Count();
            if (itemCount > 2)
            {
                var dataBeforeLast = orderedMessages.ElementAt(itemCount - 2);
                result.TimeDiff = (lastData.ReceiveTime - dataBeforeLast.ReceiveTime).TotalMilliseconds / 1000;
            }

            result.MessageCount = itemCount + 1;
            result.Time = lastData.ReceiveTime;
            result.Ip = lastData.PosUdpData.Meta.Sender.Address;
            result.DataSyncName = lastData.PosUdpData.Meta.Name;

            return result;
        }
    }
}
