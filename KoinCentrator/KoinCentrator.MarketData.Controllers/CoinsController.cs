using KoinCentrator.MarketData.Providers;
using KoinCentrator.Tools.Web;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
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

        //[HttpGet]
        //[Route("all")]
        //public async Task<IActionResult> GetAllCoinsAsync()
        //{

        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAllCoinsAsync([CommaSeparated]IEnumerable<string> commaSeparatedSymbols)
        //{

        //}
    }
}
