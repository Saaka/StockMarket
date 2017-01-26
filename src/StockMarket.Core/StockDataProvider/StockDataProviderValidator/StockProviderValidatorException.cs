using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.StockDataProvider.StockDataProviderValidator
{
    public class StockProviderValidatorException : Exception
    {
        public StockProviderValidatorException(string message)
            : base(message)
        {

        }
    }
}
