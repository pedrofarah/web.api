using FluentValidation;
using MediatR;
using PedroFarah.Web.Api.Domain.Commands;
using PedroFarah.Web.Api.Entity;
using PedroFarah.Web.Api.Infrastructure.Interfaces.DataModule;

namespace PedroFarah.Web.Api.Domain.CommandHandler
{
    public class OrderCommandHandler : 
        IRequestHandler<AddOrderCommand, Order>,
        IRequestHandler<DeleteOrderCommand, long>
    {
        private readonly IDataModule _dataModule;
        
        private readonly IValidator<AddOrderCommand> _addOrderCommandValidator;
        private readonly IValidator<DeleteOrderCommand> _deleteOrderCommandValidator;

        public OrderCommandHandler(IDataModule dataModule, 
            IValidator<AddOrderCommand> orderCommandValidator,
            IValidator<DeleteOrderCommand> deleteOrderCommandValidator)
        {
            this._dataModule = dataModule;
            this._addOrderCommandValidator = orderCommandValidator;
            this._deleteOrderCommandValidator = deleteOrderCommandValidator;
        }

        public async Task<Order> Handle(AddOrderCommand addOrderCommand, CancellationToken cancellationToken)
        {
            this._addOrderCommandValidator.ValidateAndThrow(addOrderCommand);

            var result = await this._dataModule.OrderRepository.AddAsync(new Order
            {
                Amount = 0,
                DateTime = addOrderCommand.DateTime,
                PersonDocument = addOrderCommand.PersonDocument,
            });

            await this._dataModule.CommitDataAsync();

            return result;
        }

        public async Task<long> Handle(DeleteOrderCommand deleteOrderCommand, CancellationToken cancellationToken)
        {
            this._deleteOrderCommandValidator.ValidateAndThrow(deleteOrderCommand);

            await this._dataModule.StartTransactionAsync();
            
            try
            {
                var order = await this._dataModule.OrderRepository.GetAsync(x => x.Id == deleteOrderCommand.Id)
                    ?? throw new ArgumentException("Não foi possível localizar as informações da venda informada.");

                this._dataModule.OrderRepository.Delete(new List<Order>() { order });

                await this._dataModule.CommitDataAsync();

                return order.Id;
            }
            catch
            {
                this._dataModule.RollbackTransaction();
                throw;
            }
           
        }

    }
}
