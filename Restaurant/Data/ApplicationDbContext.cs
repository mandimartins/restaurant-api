﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data.EntityTypeConfiguration;

namespace Restaurant.Data
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfig());
            builder.ApplyConfiguration(new ProductConfig());
            builder.ApplyConfiguration(new OrderConfig());
            builder.ApplyConfiguration(new OrderItemConfig());
            builder.ApplyConfiguration(new MenuConfig());
            builder.ApplyConfiguration(new MenuItemConfig());
            base.OnModelCreating(builder);
        }
    }
}
