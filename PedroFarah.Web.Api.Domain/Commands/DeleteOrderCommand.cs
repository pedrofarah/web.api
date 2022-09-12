using MediatR;

namespace PedroFarah.Web.Api.Domain.Commands
{
    public class DeleteOrderCommand : IRequest<long>
    {
        public long Id { get; set; }
    }
}
