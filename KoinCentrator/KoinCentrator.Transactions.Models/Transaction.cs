using System;

namespace KoinCentrator.Transactions.Models
{
    public class Transaction
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public DateTime DateTime { get; set; }
        public (TransactionSide, TransactionSide) Sides { get; set; }
    }

    public class TransactionSide
    {
        public string PartyId { get; set; }
        public string Symbol { get; set; }
        public decimal Quantity { get; set; }
    }
}
