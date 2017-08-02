using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoinCentrator.MarketData.Models;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace KoinCentrator.MarketData.Providers.Coinigy
{
    public class CoinigyQuoteProvider : IQuoteProvider
    {
        public readonly HttpClient _client;

        public CoinigyQuoteProvider() : this(new HttpClient())
        {
        }

        public CoinigyQuoteProvider(HttpClient client)
        {
            _client = client ?? new HttpClient();
            _client.DefaultRequestHeaders.Add("X-API-KEY", apiKey);
            _client.DefaultRequestHeaders.Add("X-API-SECRET", apiSecret);
        }

        private const string apiKey = "6744e89f96308560f548ad1d8eecd478";
        private const string apiSecret = "5f03cfb4b8a196c636ffa2c2807a9ace";

        public string Id => "Coinigy";

        public async Task<Quote> GetQuoteAsync(string symbol, string targetSymbol) =>
            (await GetQuotesAsync(new[] { symbol }, targetSymbol)).SingleOrDefault();

        public async Task<IEnumerable<Quote>> GetQuotesAsync(IEnumerable<string> symbols, string targetSymbol)
        {
            string uri = "https://api.coinigy.com/api/v1/ticker";
            HttpResponseMessage[] responses = await Task.WhenAll(symbols.Select(s => _client.PostAsync(
                uri,
                new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("exchange_code", "GDAX"),
                    new KeyValuePair<string, string>("exchange_market", $"{s}/{targetSymbol}")
                })
            )));

            var contents = new List<string>();
            foreach (HttpResponseMessage response in responses.Where(r => r.IsSuccessStatusCode))
                contents.Add(await response.Content.ReadAsStringAsync());

            return contents.Select(c => JsonConvert.DeserializeObject<QueryDto>(c))
                .SelectMany(q => q.data)
                .Select(q => new Quote
                {
                    Ask = q.ask,
                    Bid = q.bid,
                    ExchangeId = q.exchange,
                    LastUpdated = q.timestamp,
                    Symbol = q.market.Split('/')[0],
                    TargetSymbol = q.market.Split('/')[1],
                    Volume = q.current_volume,
                    High = q.high_trade,
                    Low = q.low_trade,
                    Last = q.last_trade
                });
        }

        private class QueryDto
        {
            public List<DataDto> data { get; set; }
        }

        private class DataDto
        {
            public string exchange { get; set; }
            public string market { get; set; }
            public decimal last_trade { get; set; }
            public decimal high_trade { get; set; }
            public decimal low_trade { get; set; }
            public decimal current_volume { get; set; }
            public DateTime timestamp { get; set; }
            public decimal bid { get; set; }
            public decimal ask { get; set; }
        }
    }
}
