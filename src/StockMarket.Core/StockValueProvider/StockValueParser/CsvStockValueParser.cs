using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.StockValueProvider.StockValueParser
{
    public class CsvStockValueParser : IStockValueParser
    {
        public decimal GetParsedValue(string data)
        {
            var dataArray = data.Split(',');

            if (dataArray.Length < 8)
                throw new StockValueParserException($"Specified stock data format is invalid, not enough data columns: {data}");

            var stringValue = dataArray[6].Replace('.',',');
            decimal value = 0;

            if (!decimal.TryParse(stringValue, out value))
                throw new StockValueParserException($"Specified value is not valid decimal number: {stringValue}");

            return value;
        }
    }
}
