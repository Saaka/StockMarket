using StockMarket.Core.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace StockMarket.IntegrationTests
{
    public class JsonFileAppConfigurationProviderTests
    {
        [Fact]
        public void ShouldReturnDefaultConfigurationWhenFileDoesNotExists()
        {
            RemoveConfigFile();
            var configProvider = GetProvider();

            var config = configProvider.GetConfiguration();

            Assert.Equal(60, config.Interval);
            Assert.Equal(5, config.Stocks.Length);
            Assert.Contains("WIG", config.Stocks);
            Assert.Contains("WIG20", config.Stocks);
            Assert.Contains("FW20", config.Stocks);
            Assert.Contains("MWIG40", config.Stocks);
            Assert.Contains("SWIG80", config.Stocks);
        }

        private void RemoveConfigFile()
        {
            File.Delete(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "config.json"));
        }

        private IAppConfigurationProvider GetProvider()
        {
            return new JsonFileAppConfigurationProvider();
        }
    }
}
