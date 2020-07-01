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
    public class CreateUserValidator : AbstractValidator<UserDto>
    {

        public CreateUserValidator(BlogContext context) {



            RuleFor(x => x.FirstName).NotEmpty().Must(name => context.Users.Any(d => d.FirstName == name)).WithMessage("First name must be unique");
                       }

    }
}
