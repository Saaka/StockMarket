﻿using StockMarket.Core.StockStorage.StockStorageParser;
using StockMarket.Core.StockValueProvider;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace StockMarket.Core.StockStorage
{
    public class LocalFileStockStorage : IStockStorage
    {
        private readonly IStockStorageParser storageParser;
        private readonly string storagePath;

        public LocalFileStockStorage(IStockStorageParser storageParser)
        {
            storagePath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Storage");
            this.storageParser = storageParser;
        }

        public async Task SaveStockValue(StockValue stock)
        {
            CreateStoragePathIfNotExists();
            using (var writer = File.AppendText(GetStockFilePath(stock.Name)))
            {
                await writer.WriteLineAsync($"{stock.Date};{stock.Value}");
            }
        }

        public async Task<LoadStockResult> LoadLastSavedValue(string stockName)
        {
            if (!File.Exists(GetStockFilePath(stockName)))
                return new LoadStockResult(false);
            else
            {
                string lastValue = string.Empty;
                await Task.Run(() =>
                {
                    lastValue = File.ReadAllLines(GetStockFilePath(stockName)).Last();
                });
                return new LoadStockResult(true, storageParser.GetParsedStockValue(stockName, lastValue));
            }
        }

        private void CreateStoragePathIfNotExists()
        {
            if (!Directory.Exists(storagePath))
                Directory.CreateDirectory(storagePath);
        }

        private string GetStockFilePath(string stockName)
        {
            return Path.Combine(storagePath, $"{stockName}.txt");
        }
    }
}
