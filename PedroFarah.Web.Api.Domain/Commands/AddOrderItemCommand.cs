using MediatR;
using PedroFarah.Web.Api.Entity;
using System;

namespace PedroFarah.Web.Api.Domain.Commands
{
    public class AddOrderItemCommand : IRequest<long>
    {

        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitValue { get; set; }
    }
}
