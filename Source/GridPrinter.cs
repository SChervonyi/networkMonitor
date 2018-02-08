using System;
using System.Collections.Generic;
using System.Text;
using myApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace myApp
{
    public static class GridPrinter
    {
        public static void Print(ICollection<PrintModel> messageGrid)
        {
            var strBuilder = new StringBuilder();
            strBuilder.AppendLine("DataSync name| IP | Time |Time diff (s)| Message Count | Last Message");
            foreach (var item in messageGrid)
            {
                string line = $"{item.DataSyncName} | {item.Ip} |"
                    + $"{item.Time} | {item.TimeDiff} | {item.MessageCount}";
                strBuilder.AppendLine(line);
            }
            strBuilder.AppendLine("__________________________");

            Console.Clear();
            Console.WriteLine(strBuilder.ToString());
        }
    }
}