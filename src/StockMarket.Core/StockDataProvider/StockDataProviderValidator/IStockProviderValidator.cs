using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.StockDataProvider.StockDataProviderValidator
{
    public interface IStockDataProviderValidator
    {
        void ValidateStock(string stockName, string result);
    }
}
