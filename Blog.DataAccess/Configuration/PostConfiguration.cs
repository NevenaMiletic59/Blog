using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DataAccess.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.HasIndex(p => p.Name).IsUnique();


            builder.Property(p => p.Description).IsRequired().HasMaxLength(200);

            builder.HasMany(p => p.comments)
              .WithOne(cp => cp.post)
              .HasForeignKey(cp => cp.IdPost)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.pictures).WithOne(cp => cp.post).HasForeignKey(cp => cp.IdPost).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
