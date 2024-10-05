using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Data.Models;

namespace Restaurant.Data.EntityTypeConfiguration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(35);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.ImageUrl)
                .IsRequired(false)
                .HasMaxLength(2048);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.IdCategory);
        }
    }
}
