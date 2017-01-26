using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.StockStorage.StockStorageParser
{
    public class StockStorageParserException : Exception
    {
        public StockStorageParserException(string message)
            :base(message)
        {

        }
    }
}
