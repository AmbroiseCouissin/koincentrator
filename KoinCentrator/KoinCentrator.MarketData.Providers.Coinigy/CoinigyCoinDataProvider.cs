using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KoinCentrator.MarketData.Models;
using System.Net.Http;

namespace KoinCentrator.MarketData.Providers.Coinigy
{
    public class CoinigyCoinDataProvider : ICoinDataProvider
    {
        public readonly HttpClient _client;

        public CoinigyCoinDataProvider() : this(new HttpClient())
        {
        }

        public CoinigyCoinDataProvider(HttpClient client)
        {
            _client = client ?? new HttpClient();
            _client.DefaultRequestHeaders.Add("X-API-KEY", apiKey);
            _client.DefaultRequestHeaders.Add("X-API-SECRET", apiSecret);
        }

        private const string apiKey = "6744e89f96308560f548ad1d8eecd478";
        private const string apiSecret = "5f03cfb4b8a196c636ffa2c2807a9ace";

        public string Id => "Coinigy";

        public Task<IEnumerable<Coin>> GetAllCoinDatasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Coin> GetCoinDataAsync(string exchangeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Coin>> GetCoinDatasAsync(IEnumerable<string> exchangeIds)
        {
            throw new NotImplementedException();
        }
    }
}
