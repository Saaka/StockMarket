using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.StockProvider
{
    public interface IStockProvider
    {
        Task<string> GetStockValue(string stockName);
    }
}
