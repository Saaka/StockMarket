using System.Threading.Tasks;

namespace StockMarket.Core.StockValue
{
    public interface IStockValueProvider
    {
        Task<StockValue> GetStockValue(string stockName);
    }
}