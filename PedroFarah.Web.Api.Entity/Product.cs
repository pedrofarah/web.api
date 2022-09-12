using System.Collections.Generic;

namespace PedroFarah.Web.Api.Entity
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public long ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
