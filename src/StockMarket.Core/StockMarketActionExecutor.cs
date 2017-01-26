using StockMarket.Core.Configuration;
using StockMarket.Core.Logger;
using StockMarket.Core.StockActionResolver;
using StockMarket.Core.StockDataProvider.StockDataProviderValidator;
using StockMarket.Core.StockStorage;
using StockMarket.Core.StockStorage.StockStorageParser;
using StockMarket.Core.StockValueProvider;
using StockMarket.Core.StockValueProvider.StockValueParser;
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
        private readonly IStockActionResolver actionResolver;

        public StockMarketActionExecutor(IAppLogger logger,
            IAppConfigurationProvider configProvider,
            IStockStorage stockStorage,
            IStockValueProvider stockValueProvider,
            IStockActionResolver actionResolver)
        {
            this.logger = logger;
            this.configProvider = configProvider;
            this.stockStorage = stockStorage;
            this.stockValueProvider = stockValueProvider;
            this.actionResolver = actionResolver;
        }

        public async Task RunStockMarket()
        {
            logger.Info("Stock market is running");

            while(true)
            {
                logger.Info("Loading new configuration");
                var config = configProvider.GetConfiguration();
                logger.Info($"Waiting {config.Interval} seconds for next data read");

                var waitTask = Task.Delay(TimeSpan.FromSeconds(config.Interval));
                await waitTask;

                var result = await ExecuteStockMarketAction(config.Stocks);
                if(result.IsSuccess)
                {
                    logger.Info("Action succeded. Stock values updated");
                }
                else
                {
                    logger.Info("Stock market application is waiting to terminate");
                    return;
                }
            }
        }

        private async Task<StockMarketActionResult> ExecuteStockMarketAction(string[] stocks)
        {
            try
            {
                foreach (var stockName in stocks)
                {
                    try
                    {
                        logger.Info($"Loading data for {stockName}");
                        bool saveValue = false;
                        var newStockValue = await stockValueProvider.GetStockValue(stockName);
                        var lastStockValue = await stockStorage.LoadLastSavedValue(stockName);
                        if (!lastStockValue.ValueExists)
                            saveValue = true;
                        else if (actionResolver.ShouldSaveStock(newStockValue, lastStockValue.StockValue))
                            saveValue = true;

                        if (saveValue)
                        {
                            logger.Info($"Saving value for {stockName}");
                            await stockStorage.SaveStockValue(newStockValue);
                            logger.Info($"Value for {stockName} saved");
                        }
                        else
                            logger.Info($"No changes for {stockName}");
                    }
                    catch (Exception ex) when (ex is StockValueParserException || ex is StockProviderValidatorException || ex is StockStorageParserException)
                    {
                        logger.Error(ex);
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                        return new StockMarketActionResult(false, ex.Message);
                    }
                }

                return new StockMarketActionResult(true);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new StockMarketActionResult(false, ex.Message);
            }
        }
    }
}
