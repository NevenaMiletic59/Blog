using AutoMapper;
using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Application.Email;
using Blog.DataAccess;
using Blog.Domain;
using Blog.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EFRegisterUserCommand : IRegisterUserCommand
    {
        private readonly BlogContext _context;
        private readonly RegisterUserValidator _validator;
        private readonly IEmailSender email;


        public EFRegisterUserCommand(BlogContext context, RegisterUserValidator validator, IEmailSender email)
        {
            _context = context;
            _validator = validator;
            this.email = email;
        }

        public int Id =>20;

        public string Name => "Registration user";
        private IEnumerable<int> useCasesForUser = new List<int> { 1,7,5 };
        public void Execute(RegisterUserDto request)
        {
            _validator.ValidateAndThrow(request);
            var user= new User
            {
                FirstName = request.FirstName,
                LastName=request.LastName,
                 Username=request.Username,
                 Password= EasyEncryption.SHA.ComputeSHA256Hash(request.Password),
                  Email=request.Email
            };
            _context.Users.Add(user);

           _context.SaveChanges();
            int id =user.Id;
            foreach (var uc in useCasesForUser)
            {
                _context.UserUseCase.Add(new UserUseCase
                {
                    UserId = id,
                    UseCaseId = uc
                });
            }

            _context.SaveChanges();
            email.Send(new SendEmailDto
            {
                Content = "<h2> Successful registration to Blog </h2>",
                SendTo = request.Email,
                Subject = "Successful registration"

            });
        }
    }
}
