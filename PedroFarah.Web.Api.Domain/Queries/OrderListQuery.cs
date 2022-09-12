using MediatR;
using PedroFarah.Web.Api.Entity;
using System;
using System.Collections.Generic;

namespace PedroFarah.Web.Api.Domain.Queries
{
    public class OrderListQuery : IRequest<List<Order>>
    {
        public int OffSet { get; set; }
        public int Records { get; set; }
        public string? PersonDocument { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
