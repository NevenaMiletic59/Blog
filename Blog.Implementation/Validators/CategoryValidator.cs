using Blog.Application.DataTransfer;
using Blog.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryDto>
    {
        public CategoryValidator(BlogContext _context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .Must(x => !_context.Categories.Any(c => c.CategoryName == x))
                .WithMessage("Category already exist");

        }
    }
}
