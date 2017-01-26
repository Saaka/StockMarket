using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.StockProvider.StockProviderValidator
{
    public class StockProviderValidatorException : Exception
    {
        public StockProviderValidatorException(string message)
            : base(message)
        {

        }
    }
}
