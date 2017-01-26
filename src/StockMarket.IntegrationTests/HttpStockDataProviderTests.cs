using StockMarket.Core.StockDataProvider;
using StockMarket.Core.StockDataProvider.StockDataProviderValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StockMarket.IntegrationTests
{
    public class HttpStockDataProviderTests
    {
        [Theory]
        [InlineData("WIG20")]
        [InlineData("WIG")]
        public async Task ShouldGetValidResponse(string stockName)
        {
            var stockProvider = CreateStockProvider();

            var result = await stockProvider.GetStockData(stockName);

            Assert.Contains(stockName, result);
            Assert.Contains("Symbol,Data,Czas,Otwarcie,Najwyzszy,Najnizszy,Zamkniecie,Wolumen", result);
            Assert.DoesNotContain($"{stockName.ToUpper()},B/D,B/D,B/D,B/D,B/D,B/D,B/D", result);
        }

        [Theory]
        [InlineData("WIK20")]
        [InlineData("DummyStock")]
        public async Task ShouldThrowValidatorExceptionForInvalidStock(string stockName)
        {
            var stockProvider = CreateStockProvider();

            await Assert.ThrowsAsync<StockProviderValidatorException>(async () =>
            {
                var result = await stockProvider.GetStockData(stockName);
            });
        }

        private IStockDataProvider CreateStockProvider()
        {
            return new HttpStockDataProvider(new CsvStockProviderValidator());
        }
    }
}
