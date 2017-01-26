using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.StockStorage.StockStorageParser
{
    public class LocalFileStockParser : IStockStorageParser
    {
        public StockValue GetParsedStockValue(string stockName, string stockData)
        {
            var values = stockData.Split(';');
            DateTime date;
            decimal value;

            if (values.Length < 2)
                throw new Exception($"Invalid {stockName} data: {stockData}");

            if (!DateTime.TryParse(values[0], out date))
                throw new Exception($"Can't load {stockName} date from: {values[0]}");

            if (!decimal.TryParse(values[1], out value))
                throw new Exception($"Can't load {stockName} value from: {values[1]}");

            return new StockValue(stockName, value, date);
        }
    }
}
