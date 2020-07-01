using Blog.Application.DataTransfer;
using Blog.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Validators
{
    public class CreatePictureValidator : AbstractValidator<PictureDto>
    {
        public CreatePictureValidator(BlogContext _context)
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
