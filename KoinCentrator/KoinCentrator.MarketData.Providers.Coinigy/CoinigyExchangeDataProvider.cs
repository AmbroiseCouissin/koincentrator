using System.Collections.Generic;
using System.Threading.Tasks;
using KoinCentrator.MarketData.Models;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace KoinCentrator.MarketData.Providers.Coinigy
{
    public class CoinigyExchangeDataProvider : IExchangeDataProvider
    {
        public readonly HttpClient _client;

        public CoinigyExchangeDataProvider() : this(new HttpClient())
        {
        }

        public CoinigyExchangeDataProvider(HttpClient client)
        {
            _client = client ?? new HttpClient();
            _client.DefaultRequestHeaders.Add("X-API-KEY", apiKey);
            _client.DefaultRequestHeaders.Add("X-API-SECRET", apiSecret);
        }

        private const string apiKey = "6744e89f96308560f548ad1d8eecd478";
        private const string apiSecret = "5f03cfb4b8a196c636ffa2c2807a9ace";

        public string Id => "Coinigy";

        public async Task<IEnumerable<Exchange>> GetAllExchangeDatasAsync()
        {
            string uri = "https://api.coinigy.com/api/v1/exchanges";
            HttpResponseMessage response = await _client.PostAsync(
                uri, new StringContent(""));

            string contentString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<QueryDto>(contentString)
                .data.Select(d => new Exchange
                {
                    Id = d.exch_code,
                    Name = d.exch_name,
                    ExchangeUrl = d.exch_url,
                    Fee = d.exch_fee
                });         
        }

        public async Task<Exchange> GetExchangeDataAsync(string exchangeId) =>
            (await GetExchangeDatasAsync(new[] { exchangeId })).SingleOrDefault();

        public async Task<IEnumerable<Exchange>> GetExchangeDatasAsync(IEnumerable<string> exchangeIds) =>
            (await GetAllExchangeDatasAsync())
            .Where(e => exchangeIds.Contains(e.Id));

        private class QueryDto
        {
            public List<DataDto> data { get; set; }
        }

        private class DataDto
        {
            public string exch_code { get; set; }
            public string exch_name { get; set; }
            public decimal exch_fee { get; set; }
            public string exch_url { get; set; }
        }
    }
}
