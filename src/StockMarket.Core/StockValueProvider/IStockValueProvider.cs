using System.Threading.Tasks;

namespace StockMarket.Core.StockValueProvider
{
    public interface IStockValueProvider
    {
        Task<StockValue> GetStockValue(string stockName);
    }
}