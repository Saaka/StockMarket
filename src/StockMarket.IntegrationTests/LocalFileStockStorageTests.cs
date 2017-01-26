using StockMarket.Core;
using StockMarket.Core.StockStorage;
using StockMarket.Core.StockStorage.StockStorageParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace StockMarket.IntegrationTests
{
    public class LocalFileStockStorageTests
    {
        [Fact]
        public async Task ShouldLoadLastSavedValue()
        {
            CleanDirectory();
            var firstStock = GetStockValue("dummy", 15.2m, DateTime.Now);
            var latestStock = GetStockValue("dummy", 16.3m, firstStock.Date.AddSeconds(5));
            var storage = GetStorage();

            await storage.SaveStockValue(firstStock);
            await storage.SaveStockValue(latestStock);
            var loadResult = await storage.LoadLastSavedValue("dummy");

            Assert.True(loadResult.ValueExists);
            Assert.Equal(latestStock.Name, loadResult.StockValue.Name);
            Assert.Equal(latestStock.Value, loadResult.StockValue.Value);
            Assert.Equal(latestStock.Date.TrimMilliseconds(), loadResult.StockValue.Date);
        }

        private StockValue GetStockValue(string name, decimal value, DateTime date)
        {
            return new StockValue(name, value, date);
        }

        private IStockStorage GetStorage()
        {
            return new LocalFileStockStorage(new LocalFileStockParser());
        }

        private void CleanDirectory()
        {
            Directory.Delete(StoragePath, true);
        }

        private string StoragePath { get; } = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Storage");
    }

    public static class DateTimeExtensions
    {
        //Trims miliseconds because the storage does not save them.
        public static DateTime TrimMilliseconds(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, 0);
        }
    }
}
