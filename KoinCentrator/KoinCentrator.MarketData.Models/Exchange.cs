﻿using System.Collections.Generic;

namespace KoinCentrator.MarketData.Models
{
    public class Exchange
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Fee { get; set; }
        public string ExchangeUrl { get; set; }
        public IEnumerable<string> SupportedCoinSymbols { get; set; }
    }
}
