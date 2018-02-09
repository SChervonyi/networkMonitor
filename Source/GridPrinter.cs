using System;
using System.Collections.Generic;
using System.Text;
using PosNetworkMonitor.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PosNetworkMonitor
{
    public static class GridPrinter
    {
        public static void Print(ICollection<PrintModel> messageGrid)
        {
            var strBuilder = new StringBuilder();
            strBuilder.AppendLine("DataSync name |      IP      |        Time        |Time diff (s)| Message Count |");
            strBuilder.AppendLine("__________________________________________________________________________________");
            foreach (var item in messageGrid)
            {
                strBuilder.Append($"{item.DataSyncName} | {item.Ip} |");
                strBuilder.AppendLine($" {item.Time} |        {item.TimeDiff.ToString("G3")} |           {item.MessageCount} |");
            }
            strBuilder.AppendLine("_______________________________________________________________________________________");

            Console.Clear();
            Console.WriteLine(strBuilder.ToString());
        }
    }
}