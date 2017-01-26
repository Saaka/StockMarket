using StockMarket.Core.Configuration;
using StockMarket.Core.Logger;
using StockMarket.Core.StockStorage;
using StockMarket.Core.StockValueProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core
{
    public class StockMarketActionExecutor : IStockMarketActionExecutor
    {
        private readonly IAppLogger logger;
        private readonly IAppConfigurationProvider configProvider;
        private readonly IStockStorage stockStorage;
        private readonly IStockValueProvider stockValueProvider;

        public StockMarketActionExecutor(IAppLogger logger,
            IAppConfigurationProvider configProvider,
            IStockStorage stockStorage, 
            IStockValueProvider stockValueProvider)
        {
            this.logger = logger;
            this.configProvider = configProvider;
            this.stockStorage = stockStorage;
            this.stockValueProvider = stockValueProvider;
        }

        public void RunStockMarket()
        {
            var config = configProvider.GetConfiguration();

            logger.Info("Program started");
            logger.Info($"Waiting {config.Interval} seconds for first data read");
        }

        private async Task ExecuteStockMarketAction(string[] stocks)
        {
            try
            {

            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
        }
    }
}
