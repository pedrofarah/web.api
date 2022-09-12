using MediatR;
using PedroFarah.Web.Api.Entity;

namespace PedroFarah.Web.Api.Domain.Queries
{
    public class GetOrderQuery : IRequest<Order>
    {
        public long Id { get; set; }
    }
}
