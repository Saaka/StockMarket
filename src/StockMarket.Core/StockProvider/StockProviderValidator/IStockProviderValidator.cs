using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.StockProvider.StockProviderValidator
{
    public interface IStockProviderValidator
    {
        void ValidateStock(string stockName, string result);
    }
}
