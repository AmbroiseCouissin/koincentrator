using System;

namespace KoinCentrator.Orders.Models
{
    public class Order
    {
        public string Id { get; set; }
        public OrderState State { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public string Symbol { get; set; }
        public decimal Quantity { get; set; }
    }

    public enum OrderState
    {
        New,
        Cancelled,
        Rejected,
        Pending,
        Queued,
        PartiallyFilled,
        Filled
    }
}
