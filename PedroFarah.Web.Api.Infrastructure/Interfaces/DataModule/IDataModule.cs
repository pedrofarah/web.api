using Microsoft.EntityFrameworkCore.Storage;
using PedroFarah.Web.Api.Entity;
using PedroFarah.Web.Api.Infrastructure.Interfaces.Repositories;
using System.Threading.Tasks;

namespace PedroFarah.Web.Api.Infrastructure.Interfaces.DataModule
{
    public interface IDataModule
    {
        IRepository<ProductCategory> ProductCategoryRepository { get; }
        IRepository<Product> ProductRepository { get; }
        IRepository<Order> OrderRepository { get; }
        IRepository<OrderItem> OrderItemRepository { get; }
        IDbContextTransaction CurrentTransaction { get; set; }
        Task StartTransactionAsync();
        Task CommitDataAsync();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
