using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoinCentrator.MarketData.Models;
using System.Linq;

namespace KoinCentrator.MarketData.Providers.CryptoCompare
{
    public class CryptoCompareQuoteProvider : IQuoteProvider
    {
        public string Id => "CryptoCompare";

        public async Task<Quote> GetQuoteAsync(string symbol, string targetSymbol) =>
            (await GetQuotesAsync(new[] { symbol }, targetSymbol)).SingleOrDefault();

        public Task<IEnumerable<Quote>> GetQuotesAsync(IEnumerable<string> symbols, string targetSymbol)
        {
            return Task.FromResult(Enumerable.Empty<Quote>());
        }
    }
}
