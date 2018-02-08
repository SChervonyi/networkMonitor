using System;
using System.Collections.Generic;
using myApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace myApp
{
    public static class GridPrinter
    {
        public static void Print(ICollection<PrintModel> messageGrid)
        {
            Console.Clear();
            Console.WriteLine("HEAD|HEAD|HEAD|HEAD|HEAD");
            foreach (var item in messageGrid)
            {
                string line = $"{item.DataSyncName} | {item.Ip} |"
                    + $"{item.Time} | {item.TimeDiff} | {item.MessageCount}";
                Console.WriteLine(line);
            }
            Console.WriteLine("HEAD|HEAD|HEAD|HEAD|HEAD");
        }
    }
}