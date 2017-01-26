using StockMarket.Core.StockProvider;
using StockMarket.Core.StockProvider.StockProviderValidator;
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
            IStockProvider stockProvider = CreateStockProvider();

            var result = await stockProvider.GetStockValue(stockName);

            Assert.True(true);
        }

        [Theory]
        [InlineData("WIK20")]
        [InlineData("DummyStock")]
        public async void ShouldThrowValidatorExceptionForInvalidStock(string stockName)
        {
            IStockProvider stockProvider = CreateStockProvider();

            await Assert.ThrowsAsync<StockProviderValidatorException>(async () =>
            {
                var result = await stockProvider.GetStockValue(stockName);
            });
        }

        private IStockProvider CreateStockProvider()
        {
            return new HttpStockProvider(new HttpStockProviderValidator());
        }
    }
}
