using StockMarket.Core.StockStorage.StockStorageParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StockMarket.UnitTests
{
    public class LocalFileStockParserTests
    {
        [Theory]
        [InlineData("2017-01-26 16:27:45")]
        [InlineData("17,2")]
        [InlineData("notadate;17,3")]
        [InlineData("notadate;notavalue")]
        [InlineData("2017-01-26 16:27:45;notavalue")]
        [InlineData(";")]
        [InlineData("2017-01-26 16:27:45;")]
        [InlineData(";17,2")]
        public void ShouldThrowForLackingData(string data)
        {
            var parser = CreateParser();

            Assert.Throws<StockStorageParserException>(() =>
            {
                var result = parser.GetParsedStockValue("dummy", data);
            });
        }

        [Theory]
        [InlineData("dummy", "2017-01-27 16:25:15;17,5", "2017-01-27 16:25:15", "17,5")]
        [InlineData("dummy1", "2017-01-26 12:30:15;0", "2017-01-26 12:30:15", "0")]
        [InlineData("dummy2", "2017-01-26 01:20:15;2256,5", "2017-01-26 01:20:15", "2256,5")]
        public void ShouldReturnValidParsedValues(string stockName, string stockData, DateTime dateExpected, decimal valueExpected)
        {
            var parser = CreateParser();

            var parsedStock = parser.GetParsedStockValue(stockName, stockData);
            Assert.Equal(parsedStock.Date, dateExpected);
            Assert.Equal(parsedStock.Value, valueExpected);
            Assert.Equal(parsedStock.Name, stockName);
        }

        private IStockStorageParser CreateParser()
        {
            return new LocalFileStockParser();
        }
    }
}
