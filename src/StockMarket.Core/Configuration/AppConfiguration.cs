using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.Configuration
{
    public interface IAppConfiguration
    {
        int Interval { get; set; }
        string[] Stocks { get; set; }
    }

    public class AppConfiguration : IAppConfiguration
    {
        public int Interval { get; set; }
        public string[] Stocks { get; set; }
    }
}
