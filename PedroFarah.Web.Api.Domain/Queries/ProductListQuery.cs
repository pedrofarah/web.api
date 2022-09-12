using MediatR;
using PedroFarah.Web.Api.Entity;
using System.Collections.Generic;

namespace PedroFarah.Web.Api.Domain.Queries
{
    public class ProductListQuery : IRequest<List<Product>>
    {
        public int OffSet { get; set; }
        public int Records { get; set; }
        public string ProductName { get; set; }
    }
}
