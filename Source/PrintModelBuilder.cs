﻿using System;
using System.Collections.Generic;
using System.Linq;
using PosNetworkMonitor.Models;

namespace PosNetworkMonitor
{
    public class PrintModelBuilder
    {
        public List<PrintModel> BuildPrintModelGrid(List<PosUdpMessage> messageStore)
        {
            var result = new List<PrintModel>();
            var groupByIp = messageStore.GroupBy(x => x.PosUdpData.Meta.Sender.Address);
            foreach (var item in groupByIp)
            {
                result.Add(BuildPrintModel(item));
            }
            return result;
        }

        private PrintModel BuildPrintModel(IEnumerable<PosUdpMessage> messageStore)
        {
            var result = new PrintModel();
            var orderedMessages = messageStore.OrderBy(x => x.ReceiveTime).ToList();
            var lastData = orderedMessages.Last();

            var itemCount = orderedMessages.Count;
            if (itemCount >= 2)
            {
                int itemBeforeLastIndex = itemCount - 2;
                var dataBeforeLast = orderedMessages[itemBeforeLastIndex];
                result.TimeDiff = (lastData.ReceiveTime - dataBeforeLast.ReceiveTime).TotalMilliseconds / 1000;
            }

            result.MessageCount = itemCount;
            result.Time = lastData.ReceiveTime;
            result.Ip = lastData.PosUdpData.Meta.Sender.Address;
            result.DataSyncName = lastData.PosUdpData.Meta.Name;
            result.Message = lastData.OriginalMessage;

            return result;
        }
    }
}
