using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DataAccess.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.Property(c => c.Comment).HasMaxLength(100).IsRequired();

            builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasOne(c => c.user)
             .WithMany(cp => cp.comments)
             .HasForeignKey(cp => cp.UserId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.post)
                .WithMany(cp => cp.comments)
                .HasForeignKey(cp => cp.IdPost)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
