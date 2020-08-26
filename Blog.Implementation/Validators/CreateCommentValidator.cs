using Blog.Application.DataTransfer;
using Blog.DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Validators
{
    public class CreateCommentValidator : AbstractValidator<InsertCommentDto>
    {
        public CreateCommentValidator(BlogContext context)
        {
            RuleFor(x => x.Comment).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty().Must(x => context.Users.Any(p => p.Id == x)).WithMessage("User id must be in table");
            RuleFor(x => x.PostId).NotEmpty().Must(x => context.Posts.Any(p => p.Id == x)).WithMessage("Post must exists");
        }
    }
}
