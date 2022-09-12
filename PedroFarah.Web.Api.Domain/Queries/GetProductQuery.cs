using MediatR;
using PedroFarah.Web.Api.Entity;
using System.Collections.Generic;

namespace PedroFarah.Web.Api.Domain.Queries
{
    public class GetProductQuery : IRequest<Product>
    {
        public long Id { get; set; }
    }
}
