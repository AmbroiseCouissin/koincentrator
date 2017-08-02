using KoinCentrator.MarketData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoinCentrator.MarketData.Providers
{
    public interface IExchangeDataProvider
    {
        string Id { get; }
        Task<Exchange> GetExchangeDataAsync(string exchangeId);
        Task<IEnumerable<Exchange>> GetExchangeDatasAsync(IEnumerable<string> exchangeIds);
        Task<IEnumerable<Exchange>> GetAllExchangeDatasAsync();
    }
}
