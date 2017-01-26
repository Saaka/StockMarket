using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Core.StockDataProvider.StockDataProviderValidator
{
    public class CsvStockProviderValidator : IStockDataProviderValidator
    {
        public void ValidateStock(string stockName, string result)
        {
            var rows = result.Split(new[] { "\r\n" }, StringSplitOptions.None);

            if (rows.Count() < 2)
                throw new StockProviderValidatorException($"Given result is not valid: {result}");

            if (!rows[0].Equals(ValidHeader))
                throw new StockProviderValidatorException($"Invalid stock value header: {rows[0]}");

            if (rows[1].Equals(GetInvlaidStockValue(stockName)))
                throw new StockProviderValidatorException($"Stock values are invalid for {stockName}");
        }

        private string GetInvlaidStockValue(string stockName)
        {
            return $"{stockName.ToUpper()},B/D,B/D,B/D,B/D,B/D,B/D,B/D";
        }

        private string ValidHeader { get; } = "Symbol,Data,Czas,Otwarcie,Najwyzszy,Najnizszy,Zamkniecie,Wolumen";
    }
}
