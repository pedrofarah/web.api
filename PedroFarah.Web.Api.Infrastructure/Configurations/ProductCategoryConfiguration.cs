using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedroFarah.Web.Api.Entity;

namespace PedroFarah.Web.Api.Infrastructure.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder
                .ToTable("TB_PRODUCT_CATEGORY");

            builder
                .Property(p => p.Id)
                .HasColumnName("ID")
                .IsRequired();

            builder.HasKey(e => e.Id);

            builder
                .Property(p => p.Name)
                .HasColumnName("NAME")
                .IsRequired();
        }
    }
}
