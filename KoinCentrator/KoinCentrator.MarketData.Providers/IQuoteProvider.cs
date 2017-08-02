using KoinCentrator.MarketData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoinCentrator.MarketData.Providers
{
    public interface IQuoteProvider
    {
        string Id { get; }
        Task<Quote> GetQuoteAsync(string symbol, string targetSymbol);
        Task<IEnumerable<Quote>> GetQuotesAsync(IEnumerable<string> symbols, string targetSymbol);
    }
}
