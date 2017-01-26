using StockMarket.Core.StockDataProvider;
using StockMarket.Core.StockDataProvider.StockDataProviderValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StockMarket.IntegrationTests
{
    public class HttpStockProviderTests
    {
        [Theory]
        [InlineData("WIG20")]
        [InlineData("WIG")]
        public async void ShouldGetValidResponse(string stockName)
        {
            IStockDataProvider stockProvider = CreateStockProvider();

            var result = await stockProvider.GetStockValue(stockName);

            Assert.True(true);
        }

        [Theory]
        [InlineData("WIK20")]
        [InlineData("DummyStock")]
        public async void ShouldThrowValidatorExceptionForInvalidStock(string stockName)
        {
            IStockDataProvider stockProvider = CreateStockProvider();

            await Assert.ThrowsAsync<StockProviderValidatorException>(async () =>
            {
                var result = await stockProvider.GetStockValue(stockName);
            });
        }

        private IStockDataProvider CreateStockProvider()
        {
            return new HttpStockDataProvider(new HttpStockProviderValidator());
        }
    }
}
