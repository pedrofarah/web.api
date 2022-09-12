using MediatR;

namespace PedroFarah.Web.Api.Domain.Commands
{
    public class DeleteOrderItemCommand : IRequest<long>
    {
        public long Id { get; set; }
    }
}
