using System;

namespace KoinCentrator.MarketData.Models
{
    public class CurrencyPair
    {
        public string ExchangeId { get; set; }
        public string BaseCurrencySymbol { get; set; }
        public string TargetCurrencySymbol { get; set; }
        public decimal ConversionRate { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
