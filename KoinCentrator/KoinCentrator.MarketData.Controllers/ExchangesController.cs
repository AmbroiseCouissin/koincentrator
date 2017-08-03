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
    public class ExchangesController : Controller
    {
        private readonly IEnumerable<IExchangeDataProvider> _exchangeDataProviders;

        public ExchangesController(IEnumerable<IExchangeDataProvider> exchangeDataProviders)
        {
            _exchangeDataProviders = exchangeDataProviders;
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(IEnumerable<ExchangeVm>), 200)]
        public async Task<IActionResult> GetAllExchangesAsync() =>
            Ok((await Task.WhenAll(_exchangeDataProviders.Select(edp => edp.GetAllExchangeDatasAsync())))
                .SelectMany(e => e)
                .Select(c => new ExchangeVm
                {
                    ExchangeUrl = c.ExchangeUrl,
                    Fee = c.Fee,
                    Id = c.Id,
                    Name = c.Name,
                    SupportedCoinSymbols = c.SupportedCoinSymbols
                }));

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ExchangeVm>), 200)]
        public async Task<IActionResult> GetExchangesAsync([CommaSeparated]IEnumerable<string> commaSeparatedExchangeIds) =>
            Ok((await Task.WhenAll(_exchangeDataProviders.Select(edp => edp.GetExchangeDatasAsync(commaSeparatedExchangeIds))))
                .SelectMany(e => e)
                .Select(c => new ExchangeVm
                {
                    ExchangeUrl = c.ExchangeUrl,
                    Fee = c.Fee,
                    Id = c.Id,
                    Name = c.Name,
                    SupportedCoinSymbols = c.SupportedCoinSymbols
                }));
    }
}
