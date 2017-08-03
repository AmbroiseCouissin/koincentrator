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
    public class CoinsController : Controller
    {
        private readonly IEnumerable<ICoinDataProvider> _coinDataProviders;

        public CoinsController(IEnumerable<ICoinDataProvider> coinDataProviders)
        {
            _coinDataProviders = coinDataProviders;
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(IEnumerable<CoinVm>), 200)]
        public async Task<IActionResult> GetAllCoinsAsync() =>
            Ok((await Task.WhenAll(_coinDataProviders.Select(cdp => cdp.GetAllCoinDatasAsync())))
                .SelectMany(e => e)
                .Select(c => new CoinVm
                {
                    Algorithm = c.Algorithm,
                    ImageUrl = c.ImageUrl,
                    Name = c.Name,
                    ProofType = c.ProofType,
                    SupportedExchangeIds = c.SupportedExchangeIds,
                    Symbol = c.Symbol
                }));

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CoinVm>), 200)]
        public async Task<IActionResult> GetCoinsAsync([CommaSeparated]IEnumerable<string> commaSeparatedExchangeIds) =>
            Ok((await Task.WhenAll(_coinDataProviders.Select(cdp => cdp.GetCoinDatasAsync(commaSeparatedExchangeIds))))
                .SelectMany(e => e)
                .Select(c => new CoinVm
                {
                    Algorithm = c.Algorithm,
                    ImageUrl = c.ImageUrl,
                    Name = c.Name,
                    ProofType = c.ProofType,
                    SupportedExchangeIds = c.SupportedExchangeIds,
                    Symbol = c.Symbol
                }));
    }
}
