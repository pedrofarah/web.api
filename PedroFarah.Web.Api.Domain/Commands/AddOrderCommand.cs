using MediatR;
using PedroFarah.Web.Api.Entity;
using System;

namespace PedroFarah.Web.Api.Domain.Commands
{
    public class AddOrderCommand : IRequest<Order>
    {
        public DateTime DateTime { get; set; }
        public string PersonDocument { get; set; }
    }
}
