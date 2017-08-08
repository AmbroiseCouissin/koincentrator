using System;

namespace KoinCentrator.MarketData.Models
{
    public class Quote
    {
        public string Symbol { get; set; }
        public string ExchangeId { get; set; }
        public string TargetSymbol { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
        public decimal High24h { get; set; }
        public decimal Low24h { get; set; }
        public decimal Last { get; set; }
        public decimal Volume { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
