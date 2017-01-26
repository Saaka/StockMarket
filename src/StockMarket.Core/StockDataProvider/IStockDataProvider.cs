using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.StockDataProvider
{
    public interface IStockDataProvider
    {
        Task<string> GetStockValue(string stockName);
    }
}
