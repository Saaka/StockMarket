using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.StockStorage
{
    public class LoadStockResult
    {
        public LoadStockResult(bool valueExists = false)
            :this(valueExists, null)
        {
        }

        public LoadStockResult(bool valueExists, StockValue stockValue)
        {
            ValueExists = valueExists;
            StockValue = stockValue;
        }

        public bool ValueExists { get; set; }
        public StockValue StockValue { get; set; }
    }
}
