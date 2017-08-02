using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoinCentrator.MarketData.Models;

namespace KoinCentrator.MarketData.Providers.Cryptonator
{
    public class CryptonatorQuoteProvider : IQuoteProvider
    {
        public string Id => "Cryptonator";

        public Task<Quote> GetQuoteAsync(string symbol)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Quote>> GetQuotesAsync(IEnumerable<string> symbols)
        {
            throw new NotImplementedException();
        }
    }
}
