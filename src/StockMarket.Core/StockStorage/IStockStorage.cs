using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.StockStorage
{
    public interface IStockStorage
    {
        Task SaveStockValue(StockValue stock);
        Task<LoadStockResult> LoadLastSavedValue(string stockName);
    }
}
