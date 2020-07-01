using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DataAccess.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(cp => cp.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.Property(cp => cp.CategoryName).IsRequired().HasMaxLength(20);
            builder.HasIndex(cp => cp.CategoryName).IsUnique();

            builder.HasMany(c => c.Posts)
            .WithOne(cp => cp.Category)
            .HasForeignKey(cp => cp.CetegoryId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
    
}
