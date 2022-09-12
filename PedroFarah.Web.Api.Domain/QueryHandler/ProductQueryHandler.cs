using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PedroFarah.Web.Api.Domain.Queries;
using PedroFarah.Web.Api.Entity;
using PedroFarah.Web.Api.Infrastructure.Interfaces.DataModule;

namespace PedroFarah.Web.Api.Domain.QueryHandler
{
    public class ProductQueryHandler : 
        IRequestHandler<ProductListQuery, List<Product>>,
        IRequestHandler<GetProductQuery, Product>
    {
        private readonly IDataModule _dataModule;
        private readonly IValidator<ProductListQuery> _getProductListQueryValidator;
        private readonly IValidator<GetProductQuery> _getProductQueryValidator;

        public ProductQueryHandler(
            IDataModule dataModule, 
            IValidator<GetProductQuery> getProductQueryValidator,
            IValidator<ProductListQuery> getProductListQueryValidator)
        {
            this._dataModule = dataModule;
            this._getProductQueryValidator = getProductQueryValidator;
            this._getProductListQueryValidator = getProductListQueryValidator;
        }

        public async Task<List<Product>> Handle(ProductListQuery productQuery, CancellationToken cancellationToken)
        {
            this._getProductListQueryValidator.ValidateAndThrow(productQuery);

            return await this._dataModule.ProductRepository
            .DbSet
            .Include(p => p.ProductCategory)
            .Where(x => x.Name.StartsWith(productQuery.ProductName))
            .Select(x => new Product
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                ProductCategoryId = x.ProductCategoryId,
                ProductCategory = new ProductCategory
                {
                    Id = x.ProductCategory.Id,
                    Name = x.ProductCategory.Name
                }
            })
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .Skip(productQuery.OffSet - 1)
            .Take(productQuery.Records)
            .ToListAsync();

        }

        public async Task<Product> Handle(GetProductQuery productQuery, CancellationToken cancellationToken)
        {
            this._getProductQueryValidator.ValidateAndThrow(productQuery);

            return await this._dataModule.ProductRepository
            .DbSet
            .Include(p => p.ProductCategory)
            .Select(x => new Product
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                ProductCategoryId = x.ProductCategoryId,
                ProductCategory = new ProductCategory
                {
                    Id = x.ProductCategory.Id,
                    Name = x.ProductCategory.Name
                }
            })
            .FirstOrDefaultAsync(x => x.Id == productQuery.Id);
        }
    }
}
