using Blog.Application;
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
    public class EFCreateCommentCommand : ICreateCommentCommand
    {
        private readonly BlogContext _context;
        private readonly CreateCommentValidator validator;

        public EFCreateCommentCommand(BlogContext context, CreateCommentValidator validator)
        {
            _context = context;
            this.validator = validator;
        }

        public int Id => 13;

        public string Name => "Creating comment";

        public void Execute(InsertCommentDto request)
        {
            validator.ValidateAndThrow(request);
            var comment = new Comments
            {
                IdPost=request.PostId,
                 Id=request.Id,
                  Comment=request.Comment,
                   UserId=request.UserId


            };
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}
