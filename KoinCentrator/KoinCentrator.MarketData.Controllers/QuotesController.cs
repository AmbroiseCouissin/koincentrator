using KoinCentrator.MarketData.Models;
using KoinCentrator.MarketData.Providers;
using KoinCentrator.MarketData.ViewModels;
using KoinCentrator.Tools.Web;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoinCentrator.MarketData.Controllers
{
    [Route("api/[controller]")]
    public class QuotesController : Controller
    {
        private readonly IEnumerable<IQuoteProvider> _quoteProviders;

        public QuotesController(IEnumerable<IQuoteProvider> quoteProviders)
        {
            _quoteProviders = quoteProviders;
        }

        [HttpGet]
        [Route("latest")]
        public async Task<IActionResult> GetQuotesAsync([CommaSeparated]IEnumerable<string> commaSeparatedSymbols, string targetSymbol) =>
            Ok((await Task.WhenAll(_quoteProviders.Select(qp => qp.GetQuotesAsync(commaSeparatedSymbols, targetSymbol))))
                .SelectMany(q => q)
                .OrderByDescending(q => q.LastUpdated)
                .GroupBy(q => q.Symbol)
                .Select(g => g.FirstOrDefault())
                .Select(q => new QuoteVm
                {
                    Ask = q.Ask,
                    Bid = q.Bid,
                    ExchangeId = q.ExchangeId.ToString(),
                    LastUpdated = q.LastUpdated,
                    Symbol = q.Symbol,
                    TargetSymbol = q.TargetSymbol,
                    Volume = q.Volume,
                    High = q.High,
                    Low = q.Low,
                    Last = q.Last
                })
            );
    }
}
