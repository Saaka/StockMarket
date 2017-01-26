using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.StockActionResolver
{
    public class BaseStockActionResolver : IStockActionResolver
    {
        public bool ShouldSaveStock(StockValue newStockValue, StockValue oldStockValue)
        {
            return newStockValue.Value != oldStockValue.Value;
        }
    }
}
