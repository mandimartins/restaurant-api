using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Data.Models;

namespace Restaurant.Data.EntityTypeConfiguration
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdUser)
                .IsRequired();

            builder.Property(x => x.Total)
                .HasDefaultValue(0);

            builder.HasMany(x => x.OrderItem)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.IdOrder)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(o => o.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(o => o.UpdatedAt)
                .IsRequired()
                .ValueGeneratedOnAddOrUpdate();

        }
    }
}
