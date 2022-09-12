namespace PedroFarah.Web.Api.Entity
{
    public class OrderItem
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public int ItemNumber { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public decimal UnitValue { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}
