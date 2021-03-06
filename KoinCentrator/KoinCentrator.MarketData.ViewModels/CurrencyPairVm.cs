﻿using System;

namespace KoinCentrator.MarketData.ViewModels
{
    public class CurrencyPairVm
    {
        public string ExchangeId { get; set; }
        public string FromCurrencySymbol { get; set; }
        public string ToCurrencySymbol { get; set; }
        public decimal ConversionRate { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
