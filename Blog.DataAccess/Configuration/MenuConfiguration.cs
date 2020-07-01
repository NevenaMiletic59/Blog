using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DataAccess.Configuration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            

            builder.Property(m => m.Name).IsRequired().HasMaxLength(20);
            builder.Property(m => m.href).IsRequired().HasMaxLength(50);

            builder.HasIndex(m => m.Name).IsUnique();
        }
    }
}
