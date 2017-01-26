using StockMarket.Core.StockProvider.StockProviderValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StockMarket.UnitTests
{
    public class HttpStockProviderValidatorTests
    {
        [Fact]
        public void ShouldThrowExceptionForInvalidHeader()
        {
            var validator = CreateStockProviderValidator();
            var invalidResult = "WrongColumnName,Data,Czas,Otwarcie,Najwyzszy,Najnizszy,Zamkniecie,Wolumen\r\nDUMMYSTOCK,B/D,B/D,B/D,B/D,B/D,B/D,B/D";

            Assert.Throws<StockProviderValidatorException>(() =>
            {
                validator.ValidateStock("DummyStock", invalidResult);
            });
        }

        [Fact]
        public void ShouldThrowExceptionForInvalidValue()
        {
            var validator = CreateStockProviderValidator();
            var invalidResult = "Symbol,Data,Czas,Otwarcie,Najwyzszy,Najnizszy,Zamkniecie,Wolumen\r\nDUMMYSTOCK,B/D,B/D,B/D,B/D,B/D,B/D,B/D";

            Assert.Throws<StockProviderValidatorException>(() =>
            {
                validator.ValidateStock("DummyStock", invalidResult);
            });
        }

        [Theory]
        [InlineData("Symbol,Data,Czas,Otwarcie,Najwyzszy,Najnizszy,Zamkniecie,Wolumen")]
        [InlineData("DUMMYSTOCK,B/D,B/D,B/D,B/D,B/D,B/D,B/D")]
        [InlineData("")]
        public void ShouldThrowExceptionForNoValues(string invalidResult)
        {
            var validator = CreateStockProviderValidator();

            Assert.Throws<StockProviderValidatorException>(() =>
            {
                validator.ValidateStock("DummyStock", invalidResult);
            });
        }

        private IStockProviderValidator CreateStockProviderValidator()
        {
            return new HttpStockProviderValidator();
        }
    }
}
