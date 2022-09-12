using System;
using System.Collections.Generic;

namespace PedroFarah.Web.Api.Entity
{
    public class Order
    {
        public long Id { get; set; }
        public DateTime DateTime { get; set; }
        public string PersonDocument { get; set; }
        public decimal Amount { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
