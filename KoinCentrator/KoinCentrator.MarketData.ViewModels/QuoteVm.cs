using System;

namespace KoinCentrator.MarketData.ViewModels
{
    public class QuoteVm
    {
        public string Symbol { get; set; }
        public string ExchangeId { get; set; }
        public string TargetSymbol { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Last { get; set; }
        public decimal Volume { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
