using System;

namespace KoinCentrator.MarketData.Models
{
    public class CurrencyPair
    {
        public string ExchangeId { get; set; }
        public string FromCurrencySymbol { get; set; }
        public string ToCurrencySymbol { get; set; }
        public decimal ConversionRate { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
