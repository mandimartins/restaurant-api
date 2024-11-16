using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Data.Models;

namespace Restaurant.Data.EntityTypeConfiguration
{
    public class MenuConfig : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Active)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(x => x.Title) 
                .HasMaxLength(35)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(x => x.BadgeDescription)
                .HasMaxLength(20);

            builder.Property(x => x.BadgeColor);

            builder.Property(x => x.ImageURL);

            builder.Property(x => x.ImageBase64);

            builder.HasMany(x => x.MenuItem)
                .WithOne(x => x.Menu)
                .HasForeignKey(x => x.IdMenu)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
