using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.StockActionResolver
{
    public interface IStockActionResolver
    {
        bool ShouldSaveStock(StockValue newStockValue, StockValue oldStockValue);
    }
}
