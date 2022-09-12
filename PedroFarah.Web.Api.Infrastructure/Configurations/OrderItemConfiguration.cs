using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedroFarah.Web.Api.Entity;

namespace PedroFarah.Web.Api.Infrastructure.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder
                .ToTable("TB_ORDER_ITEM");

            builder
                .Property(p => p.Id)
                .HasColumnName("ID")
                .UseIdentityColumn(1, 1)
                .IsRequired();

            builder.HasKey(e => e.Id);

            builder
                .Property(p => p.OrderId)
                .HasColumnName("TB_ORDER_ID")
                .IsRequired();

            builder.HasOne(p => p.Order)
                .WithMany(p => p.OrderItems)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder
                .Property(p => p.ItemNumber)
                .HasColumnName("ITEM_NUMBER")
                .IsRequired();

            builder
                .Property(p => p.ProductId)
                .HasColumnName("TB_PRODUCT_ID")
                .IsRequired();

            builder.HasOne(p => p.Product)
                .WithMany(p => p.OrderItems)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(p => p.Quantity)
                .HasColumnName("QUANTITY")
                .HasColumnType("float")
                .IsRequired();

            builder
                .Property(p => p.Amount)
                .HasColumnName("AMOUNT")
                .HasColumnType("float")
                .IsRequired();

            builder
                .Property(p => p.UnitValue)
                .HasColumnName("UNIT_VALUE")
                .HasColumnType("float")
                .IsRequired();
        }
    }
}
