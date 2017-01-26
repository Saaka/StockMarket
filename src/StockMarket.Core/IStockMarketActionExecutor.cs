using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core
{
    public interface IStockMarketActionExecutor
    {
        void RunStockMarket();
    }
}
