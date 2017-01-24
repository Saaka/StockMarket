using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using Newtonsoft.Json;

namespace StockMarket.Core.Configuration
{
    public class JsonFileAppConfigurationProvider : IAppConfigurationProvider
    {
        private IConfigurationRoot configuration;

        public JsonFileAppConfigurationProvider()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", false, true);

            configuration = builder.Build();
        }

        public IAppConfiguration GetConfiguration()
        {
            AppConfiguration config = new AppConfiguration();
            ConfigurationBinder.Bind(configuration, config);

            return config;
        }
    }
}
