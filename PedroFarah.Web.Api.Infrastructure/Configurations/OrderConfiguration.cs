using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedroFarah.Web.Api.Entity;

namespace PedroFarah.Web.Api.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .ToTable("TB_ORDER");

            builder
                .Property(p => p.Id)
                .HasColumnName("ID")
                .UseIdentityColumn(1, 1)
                .IsRequired();

            builder.HasKey(e => e.Id);

            builder
                .Property(p => p.DateTime)
                .HasColumnName("DATE_TIME")
                .IsRequired();

            builder
                .Property(p => p.PersonDocument)
                .HasColumnName("PERSON_DOCUMENT")
                .IsRequired();

            builder
                .Property(p => p.Amount)
                .HasColumnName("AMOUNT")
                .HasColumnType("float")
                .IsRequired();

        }
    }
}
