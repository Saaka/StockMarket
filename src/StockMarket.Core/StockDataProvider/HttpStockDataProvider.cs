using StockMarket.Core.StockDataProvider.StockDataProviderValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockMarket.Core.StockDataProvider
{
    public class HttpStockDataProvider : IStockDataProvider
    {
        private readonly IStockDataProviderValidator stockValidator;

        public HttpStockDataProvider(IStockDataProviderValidator stockValidator)
        {
            this.stockValidator = stockValidator;
        }

        public async Task<string> GetStockData(string stockName)
        {
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(GetRequestUrl(stockName)))
                {
                    if (!response.IsSuccessStatusCode)
                        throw new StockProviderException($"Stock data provider was unable to get valid response for {stockName}");

                    string result = await response.Content.ReadAsStringAsync();
                    stockValidator.ValidateStock(stockName, result);
                    
                    return result;
                }
            }
        }

        private string GetRequestUrl(string stockName)
        {
            return $"https://stooq.pl/q/l/?s={stockName}&f=sd2t2ohlcv&h&e=csv";
        }
    }
}
