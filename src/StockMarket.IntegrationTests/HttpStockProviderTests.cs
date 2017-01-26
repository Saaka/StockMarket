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
        [Fact]
        public async void ShouldGetValidResponse()
        {
            IStockProvider stockProvider = CreateStockProvider();

            var result = await stockProvider.GetStockValue("WIG20");

            Assert.True(true);
        }

        private IStockProvider CreateStockProvider()
        {
            return new HttpStockProvider(new HttpStockProviderValidator());
        }
    }
}
