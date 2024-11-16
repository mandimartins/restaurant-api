using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Data.Models;

namespace Restaurant.Data.EntityTypeConfiguration
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdOrder)
                .IsRequired();

            builder.Property(x => x.IdProduct)
                .IsRequired();

            builder.Property(x => x.Quantity)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(x => x.Price)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(x => x.PriceTotal)
                .HasDefaultValue(0)
                .IsRequired();

            builder.HasOne(x => x.Order)
                .WithMany()
                .HasForeignKey(x => x.IdOrder)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.IdProduct)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
