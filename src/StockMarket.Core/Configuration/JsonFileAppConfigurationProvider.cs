using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;

namespace StockMarket.Core.Configuration
{
    public class JsonFileAppConfigurationProvider : IAppConfigurationProvider
    {
        private readonly IConfigurationRoot configuration;

        public JsonFileAppConfigurationProvider()
        {
            if (!File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "config.json")))
            {
                CreateDefaultConfigFile(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "config.json"));
            }
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                .AddJsonFile("config.json", false, true);

            configuration = builder.Build();
        }

        private void CreateDefaultConfigFile(string filePath)
        {
            var file = JsonConvert.SerializeObject(new AppConfiguration
            {
                Interval = 60,
                Stocks = new[] { "WIG", "WIG20", "FW20", "MWIG40", "SWIG80" }
            });

            File.WriteAllText(filePath, file);
        }


        public IAppConfiguration GetConfiguration()
        {
            var config = new AppConfiguration();
            ConfigurationBinder.Bind(configuration, config);

            return config;
        }
    }
}
