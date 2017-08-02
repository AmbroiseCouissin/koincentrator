using KoinCentrator.MarketData.Providers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoinCentrator.MarketData.Controllers
{
    [Route("api/[controller]")]
    public class QuotesController
    {
        private readonly IEnumerable<IQuoteProvider> _quoteProviders;

        public QuotesController(IEnumerable<IQuoteProvider> quoteProviders)
        {
            _quoteProviders = quoteProviders;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuotesAsync(string commaSeparatedSymbols)
        {
            throw new NotImplementedException();
        }
    }
}
