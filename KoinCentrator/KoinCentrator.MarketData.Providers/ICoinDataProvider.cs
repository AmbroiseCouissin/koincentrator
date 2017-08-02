using KoinCentrator.MarketData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoinCentrator.MarketData.Providers
{
    public interface ICoinDataProvider
    {
        string Id { get; }
        Task<Coin> GetCoinDataAsync(string exchangeId);
        Task<IEnumerable<Coin>> GetCoinDatasAsync(IEnumerable<string> exchangeIds);
        Task<IEnumerable<Coin>> GetAllCoinDatasAsync();
    }
}
