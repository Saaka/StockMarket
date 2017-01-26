using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.StockStorage.StockStorageParser
{
    public interface IStockStorageParser
    {
        StockValue GetParsedStockValue(string stockName, string stockData);
    }
}
