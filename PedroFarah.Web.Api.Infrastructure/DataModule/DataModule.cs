using Microsoft.EntityFrameworkCore.Storage;
using PedroFarah.Web.Api.Entity;
using PedroFarah.Web.Api.Infrastructure.Context;
using PedroFarah.Web.Api.Infrastructure.Interfaces.DataModule;
using PedroFarah.Web.Api.Infrastructure.Interfaces.Repositories;
using PedroFarah.Web.Api.Infrastructure.Repositories;

namespace PedroFarah.Web.Api.Infrastructure.DataModule
{
    public class DataModule : IDataModule, IDisposable
    {
        public DataModule(ApplicationDbContext dbContext)
        {
            CurrentContext = dbContext;
        }

        public readonly ApplicationDbContext CurrentContext;

        public IDbContextTransaction CurrentTransaction { get; set; }

        private bool ActiveTransaction { get; set; } = false;

        private bool _disposed = false;

        private IRepository<ProductCategory> productCategoryRepository = null;
        public IRepository<ProductCategory> ProductCategoryRepository
        {
            get => productCategoryRepository ??= new Repository<ProductCategory>(CurrentContext);
        }

        private IRepository<Product> productRepository = null;
        public IRepository<Product> ProductRepository
        {
            get => productRepository ??= new Repository<Product>(CurrentContext);
        }

        private IRepository<Order> orderRepository = null;
        public IRepository<Order> OrderRepository
        {
            get => orderRepository ??= new Repository<Order>(CurrentContext);
        }

        private IRepository<OrderItem> orderItemRepository = null;
        public IRepository<OrderItem> OrderItemRepository
        {
            get => orderItemRepository ??= new Repository<OrderItem>(CurrentContext);
        }

        public async Task StartTransactionAsync()
        {
            CurrentTransaction = await CurrentContext.Database.BeginTransactionAsync();
            ActiveTransaction = true;
        }

        public async Task CommitDataAsync()
        {
            await CurrentContext.SaveChangesAsync();
            if (ActiveTransaction)
                CommitTransaction();
        }

        public void CommitTransaction()
        {
            if (ActiveTransaction)
                CurrentContext.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            if (ActiveTransaction)
                CurrentContext.Database.RollbackTransaction();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed && disposing)
            {
                CurrentContext.Dispose();
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}