using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PedroFarah.Web.Api.Domain.Queries;
using PedroFarah.Web.Api.Entity;
using PedroFarah.Web.Api.Infrastructure.Interfaces.DataModule;

namespace PedroFarah.Web.Api.Domain.QueryHandler
{
    public class OrderQueryHandler : 
        IRequestHandler<OrderListQuery, List<Order>>,
        IRequestHandler<GetOrderQuery, Order>
    {
        private readonly IDataModule _dataModule;
        private readonly IValidator<OrderListQuery> _orderListQueryValidator;
        private readonly IValidator<GetOrderQuery> _getOrderQueryValidator;

        public OrderQueryHandler(
            IDataModule dataModule,
            IValidator<OrderListQuery> orderListQueryValidator,
            IValidator<GetOrderQuery> getOrderQueryValidator)
        {
            this._dataModule = dataModule;
            this._orderListQueryValidator = orderListQueryValidator;
            this._getOrderQueryValidator = getOrderQueryValidator;
        }

        public async Task<List<Order>> Handle(OrderListQuery orderListQuery, CancellationToken cancellationToken)
        {
            this._orderListQueryValidator.ValidateAndThrow(orderListQuery);

            return await this._dataModule.OrderRepository
            .DbSet
            .Include(i => i.OrderItems).ThenInclude(t => t.Product)
            .Where(x => 
                x.PersonDocument.Contains(orderListQuery.PersonDocument ?? String.Empty) 
                && x.DateTime >= orderListQuery.StartDate 
                && x.DateTime <= orderListQuery.EndDate)
            .Select(x => new Order
            {
                Amount = x.Amount,
                DateTime = x.DateTime,
                Id = x.Id,
                PersonDocument = x.PersonDocument,
                OrderItems = x.OrderItems.Select(i => new OrderItem
                {
                    Amount = i.Amount,
                    Id = i.Id,
                    ItemNumber = i.ItemNumber,
                    Quantity = i.Quantity,
                    Product = new Product
                    {
                        Id = i.Product.Id,
                        Name = i.Product.Name
                    },
                    UnitValue = i.UnitValue
                }).ToList()
            })
            .OrderBy(x => x.DateTime)
            .Skip(orderListQuery.OffSet - 1)
            .Take(orderListQuery.Records)
            .ToListAsync();
        }


        public async Task<Order> Handle(GetOrderQuery getOrderQuery, CancellationToken cancellationToken)
        {
            this._getOrderQueryValidator.ValidateAndThrow(getOrderQuery);

            return await this._dataModule.OrderRepository
            .DbSet
            .Include(i => i.OrderItems).ThenInclude(t => t.Product)
            .Select(x => new Order
            {
                Amount = x.Amount,
                DateTime = x.DateTime,
                Id = x.Id,
                PersonDocument = x.PersonDocument,
                OrderItems = x.OrderItems.Select(i => new OrderItem
                {
                    Amount = i.Amount,
                    Id = i.Id,
                    ItemNumber = i.ItemNumber,
                    Quantity = i.Quantity,
                    Product = new Product
                    {
                        Id = i.Product.Id,
                        Name = i.Product.Name
                    },
                    UnitValue = i.UnitValue
                }).ToList()
            })
            .FirstOrDefaultAsync(x => x.Id == getOrderQuery.Id);
        }
    }
}
