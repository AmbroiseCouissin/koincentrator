using System.Collections.Generic;

namespace KoinCentrator.MarketData.Models
{
    public class Coin
    {
        public string Symbol { get; set; }
        public IEnumerable<string> SupportedExchangeIds { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Algorithm { get; set; }
        public string ProofType { get; set; }
    }
}
