using StockMarket.Core.DateProvider;
using StockMarket.Core.StockDataProvider;
using StockMarket.Core.StockValue.StockValueParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.StockValue
{
    public class CsvStockValueProvider : IStockValueProvider
    {
        private readonly IStockDataProvider stockDataProvider;
        private readonly IStockValueParser valueParser;
        private readonly IDateProvider dateProvider;

        public CsvStockValueProvider(IStockDataProvider stockDataProvider, IStockValueParser valueParser, IDateProvider dateProvider)
        {
            this.stockDataProvider = stockDataProvider;
            this.valueParser = valueParser;
            this.dateProvider = dateProvider;
        }

        public async Task<StockValue> GetStockValue(string stockName)
        {
            var stockCsvData = await stockDataProvider.GetStockData(stockName);
            var stockData = stockCsvData.Split(new[] { @"\r\n" }, StringSplitOptions.None)[1];            
            var stockValue = valueParser.GetParsedValue(stockData);

            return new StockValue(stockName, stockValue, dateProvider.GetCurrentDateTime());
        }
    }
}
