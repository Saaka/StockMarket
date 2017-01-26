using StockMarket.Core.StockValue.StockValueParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StockMarket.UnitTests
{
    public class CsvStockValueParserTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("WIG20,2017-01-26,13:04:30,2086.78,2093.05,2074.26,2085.11")]
        [InlineData("WIG20,2017-01-26,13:04:30,2086.78,2093.05,2074.26,17359111")]
        public void ShouldThrowErrorForInvalidData(string data)
        {
            var parser = GetStockValueParser();

            Assert.Throws<StockValueParserException>(() =>
            {
                var stockData = parser.GetParsedValue(data);
            });
        }

        [Theory]
        [InlineData("WIG20,2017-01-26,13:04:30,2086.78,2093.05,2074.26,NotADecimalValue,17359111")]
        [InlineData("WIG20,2017-01-26,13:04:30,2086.78,2093.05,2074.26,,17359111")]
        public void ShouldThrowErrorForInvalidStockValue(string data)
        {
            var parser = GetStockValueParser();

            Assert.Throws<StockValueParserException>(() =>
            {
                var stockData = parser.GetParsedValue(data);
            });
        }

        [Theory]
        [InlineData("WIG20,2017-01-26,13:04:30,2086.78,2093.05,2074.26,15,17359111", "15,0")]
        [InlineData("WIG20,2017-01-26,13:04:30,2086.78,2093.05,2074.26,21.2,17359111", "21,2")]
        [InlineData("WIG20,2017-01-26,13:04:30,2086.78,2093.05,2074.26,2261.89,17359111", "2261,89")]
        [InlineData("WIG20,2017-01-26,13:04:30,2086.78,2093.05,2074.26,0,17359111", "0")]
        public void ShouldReturnValidValueForParsedData(string data, decimal expectedValue)
        {
            var parser = GetStockValueParser();

            var stockData = parser.GetParsedValue(data);

            Assert.Equal(stockData, expectedValue, 5);
        }

        private IStockValueParser GetStockValueParser()
        {
            return new CsvStockValueParser();
        }
    }
}
