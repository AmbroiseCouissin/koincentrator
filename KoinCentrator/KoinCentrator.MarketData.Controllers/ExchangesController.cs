using KoinCentrator.MarketData.Providers;
using KoinCentrator.Tools.Web;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoinCentrator.MarketData.Controllers
{
    [Route("api/[controller]")]
    public class ExchangesController : Controller
    {
        private readonly IEnumerable<IExchangeDataProvider> _exchangeDataProviders;

        public ExchangesController(IEnumerable<IExchangeDataProvider> exchangeDataProviders)
        {
            _exchangeDataProviders = exchangeDataProviders;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllExchangesAsync() =>
            Ok((await Task.WhenAll(_exchangeDataProviders.Select(edp => edp.GetAllExchangeDatasAsync())))
                .SelectMany(e => e));

        [HttpGet]
        public async Task<IActionResult> GetExchangesAsync([CommaSeparated]IEnumerable<string> commaSeparatedExchangeIds) =>
            Ok((await Task.WhenAll(_exchangeDataProviders.Select(edp => edp.GetExchangeDatasAsync(commaSeparatedExchangeIds))))
                .SelectMany(e => e));
    }
}
