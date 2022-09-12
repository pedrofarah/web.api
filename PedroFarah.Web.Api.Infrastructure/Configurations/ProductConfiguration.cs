using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedroFarah.Web.Api.Entity;

namespace PedroFarah.Web.Api.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .ToTable("TB_PRODUCT");

            builder
                .Property(p => p.Id)
                .HasColumnName("ID")
                .UseIdentityColumn(1,1)
                .IsRequired();

            builder.HasKey(e => e.Id);

            builder
                .Property(p => p.Name)
                .HasColumnName("NAME")
                .IsRequired();

            builder
                .Property(p => p.Price)
                .HasColumnName("PRICE")
                .HasColumnType("float")
                .IsRequired();

            builder
                .Property(p => p.ProductCategoryId)
                .HasColumnName("TB_PRODUCT_CATEGORY_ID")
                .IsRequired();

            builder.HasOne(p => p.ProductCategory)
                .WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
