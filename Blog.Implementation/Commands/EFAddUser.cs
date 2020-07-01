using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.DataAccess;
using Blog.Domain;
using Blog.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EFAddUser : ICreateUserCommand
    {
        private readonly BlogContext _context;
        private readonly CreateUserValidator _validator;

        public EFAddUser(BlogContext context, CreateUserValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 1;

        public string Name => "Creating new user using Ef";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);
            var user = new User
            {
                 FirstName=request.FirstName,
                  LastName=request.LastName,
                   Email=request.Email,
                    Password=request.Password,
                     Username=request.Username, 
                      
            };
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
