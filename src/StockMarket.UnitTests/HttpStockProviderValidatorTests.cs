using StockMarket.Core.StockDataProvider.StockDataProviderValidator;
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

        [Theory]
        [InlineData("Symbol,Data,Czas,Otwarcie,Najwyzszy,Najnizszy,Zamkniecie,Wolumen\r\nWIG20,2017-01-26,13:04:30,2086.78,2093.05,2074.26,2085.11,17359111")]
        [InlineData("Symbol,Data,Czas,Otwarcie,Najwyzszy,Najnizszy,Zamkniecie,Wolumen\r\nWIG,2017-01-26,13:04:30,2086.78,2093.05,2074.26,2085,17359111")]
        public void ShouldBeValidatedProperly(string validResult)
        {
            var validator = CreateStockProviderValidator();
            validator.ValidateStock("DummyStock", validResult);
        }

        private IStockDataProviderValidator CreateStockProviderValidator()
        {
            return new CsvStockProviderValidator();
        }
    }
}
