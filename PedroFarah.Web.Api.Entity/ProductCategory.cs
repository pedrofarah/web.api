using System.Collections.Generic;

namespace PedroFarah.Web.Api.Entity
{
    public class ProductCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
