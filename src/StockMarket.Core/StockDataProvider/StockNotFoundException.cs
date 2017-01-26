using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.StockDataProvider
{
    public class StockNotFoundException : Exception
    {
        public StockNotFoundException(string stockName)
            :base($"Stock provider could not found value for {stockName}")
        {

        }
    }
}
