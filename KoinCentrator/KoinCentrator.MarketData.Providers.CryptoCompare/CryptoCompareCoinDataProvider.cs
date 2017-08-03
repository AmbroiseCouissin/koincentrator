using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KoinCentrator.MarketData.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;

namespace KoinCentrator.MarketData.Providers.CryptoCompare
{
    public class CryptoCompareCoinDataProvider : ICoinDataProvider
    {
        public readonly HttpClient _client;

        public CryptoCompareCoinDataProvider() : this(new HttpClient())
        {
        }

        public CryptoCompareCoinDataProvider(HttpClient client)
        {
            _client = client ?? new HttpClient();
        }

        public string Id => "CryptoCompare";

        public async Task<IEnumerable<Coin>> GetAllCoinDatasAsync()
        {
            string uri = "https://www.cryptocompare.com/api/data/coinlist/";
            HttpResponseMessage response = await _client.GetAsync(uri);

            string json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<QueryDto>(json)
                .Data.Select(c => new Coin
                {
                    Algorithm = c.Value.Algorithm,
                    ImageUrl = "",
                    Name = c.Value.CoinName,
                    Symbol = c.Key
                });
        }

        public Task<Coin> GetCoinDataAsync(string exchangeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Coin>> GetCoinDatasAsync(IEnumerable<string> exchangeIds)
        {
            throw new NotImplementedException();
        }

        private class QueryDto
        {
            public List<KeyValuePair<string, DataDto>> Data { get; set; }
        }

        private class DataDto
        {
            public string Algorithm { get; set; }
            public string CoinName { get; set; }
            public string Name { get; set; }
        }
    }
}
