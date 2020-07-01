using Blog.Application.DataTransfer;
using Blog.DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator(BlogContext context)
        {
            // i ovde isto u nekom momentu dodaj regularni izraz za first name
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(5);


            RuleFor(x => x.Username).NotEmpty()
               .Must(x => !context.Users.Any(user => user.Username == x))
               .WithMessage("Username");
               

            RuleFor(x => x.Email).NotEmpty()
                .Must(x => !context.Users.Any(user => user.Email == x))
                .WithMessage("Email is already taken")
                .EmailAddress();


        }
    }
}
