using System;

namespace KoinCentrator.MarketData.Models
{
    public class Quote
    {
        public string Symbol { get; set; }
        public ExchangeId ExchangeId { get; set; }
        public string TargetCurrencySymbol { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
        public decimal Volume { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
