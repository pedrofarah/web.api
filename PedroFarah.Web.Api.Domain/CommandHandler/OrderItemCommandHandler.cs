using FluentValidation;
using MediatR;
using PedroFarah.Web.Api.Domain.Commands;
using PedroFarah.Web.Api.Entity;
using PedroFarah.Web.Api.Infrastructure.Interfaces.DataModule;
using Microsoft.EntityFrameworkCore;

namespace PedroFarah.Web.Api.Domain.CommandHandler
{
    public class OrderItemCommandHandler : 
        IRequestHandler<AddOrderItemCommand, long>,
        IRequestHandler<DeleteOrderItemCommand, long>
    {
        private readonly IDataModule _dataModule;
        
        private readonly IValidator<AddOrderItemCommand> _addOrderItemCommandValidator;
        private readonly IValidator<DeleteOrderItemCommand> _deleteOrderItemCommandValidator;

        public OrderItemCommandHandler(IDataModule dataModule, 
            IValidator<AddOrderItemCommand> orderItemCommandValidator,
            IValidator<DeleteOrderItemCommand> deleteOrderItemCommandValidator)
        {
            this._dataModule = dataModule;
            this._addOrderItemCommandValidator = orderItemCommandValidator;
            this._deleteOrderItemCommandValidator = deleteOrderItemCommandValidator;
        }

        public async Task<long> Handle(AddOrderItemCommand addOrderItemCommand, CancellationToken cancellationToken)
        {
            this._addOrderItemCommandValidator.ValidateAndThrow(addOrderItemCommand);

            await this._dataModule.StartTransactionAsync();

            try
            { 
                var order = await this._dataModule.OrderRepository.DbSet.FindAsync(addOrderItemCommand.OrderId)
                    ?? throw new ArgumentException("Não foi possível localizar a venda informada.");

                var product = await this._dataModule.ProductRepository
                    .DbSet
                    .Select(x => new Product {
                         Id = x.Id,
                         Name = x.Name,
                         Price = x.Price
                     })
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == addOrderItemCommand.ProductId)
                ?? throw new ArgumentException("Não foi possível localizar o produto informado.");

                order.OrderItems ??= new List<OrderItem>();

                var itemNumber = order.OrderItems.OrderByDescending(x => x.ItemNumber).Select(s => s.ItemNumber).FirstOrDefault();

                var newOrderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ItemNumber = ++itemNumber,
                    ProductId = addOrderItemCommand.ProductId,
                    Quantity = addOrderItemCommand.Quantity,
                    Amount = addOrderItemCommand.UnitValue * addOrderItemCommand.Quantity,
                };

                await this._dataModule.OrderItemRepository.AddAsync(newOrderItem);

                order.Amount += newOrderItem.Amount;

                await this._dataModule.CommitDataAsync();

                return newOrderItem.Id;

            }
            catch
            {
                this._dataModule.RollbackTransaction();
                return 0;
            }
        }

        public async Task<long> Handle(DeleteOrderItemCommand deleteOrderItemCommand, CancellationToken cancellationToken)
        {
            this._deleteOrderItemCommandValidator.ValidateAndThrow(deleteOrderItemCommand);

            await this._dataModule.StartTransactionAsync();

            try
            {
                var orderItem = await this._dataModule.OrderItemRepository.GetAsync(x => x.Id == deleteOrderItemCommand.Id)
                    ?? throw new ArgumentException("Não foi possível localizar as informações do item informado.");

                var order = await this._dataModule.OrderRepository.DbSet.FindAsync(orderItem.OrderId)
                    ?? throw new ArgumentException("Não foi possível localizar as informações da venda.");

                order.Amount -= orderItem.Amount;

                this._dataModule.OrderItemRepository.Delete(new List<OrderItem>() { orderItem });

                await this._dataModule.CommitDataAsync();

                return orderItem.Id;
            }
            catch
            {
                this._dataModule.RollbackTransaction();
                throw;
            }
        }


    }
}
