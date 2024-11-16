using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Data.Models;

namespace Restaurant.Data.EntityTypeConfiguration
{
    public class MenuItemConfig : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdMenu)
                 .IsRequired();

            builder.Property(x => x.IdProduct) 
                .IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.IdProduct)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Menu)
                .WithMany()
                .HasForeignKey(x => x.IdMenu)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
