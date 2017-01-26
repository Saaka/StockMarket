using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.StockProvider
{
    public class StockProviderException : Exception
    {
        public StockProviderException(string message) :
            base(message)
        {

        }

        public StockProviderException() :
            base($"Stock provider encountered an error while getting stock values")
        {

        }
    }
}
