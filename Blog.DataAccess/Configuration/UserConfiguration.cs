using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.Property(u => u.Username).IsRequired().HasMaxLength(20);
            builder.HasIndex(u => u.Username).IsUnique();

            builder.Property(u => u.Password).IsRequired().HasMaxLength(20);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);

            builder.HasMany(c => c.posts)
               .WithOne(cp => cp.user)
               .HasForeignKey(cp => cp.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.comments)
                .WithOne(cp => cp.user)
                .HasForeignKey(cp => cp.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
