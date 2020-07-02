using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EFCreateCommentCommand : ICreateCommentCommand
    {
        private readonly BlogContext _context;

        public EFCreateCommentCommand(BlogContext context)
        {
            _context = context;
        }

        public int Id => 13;

        public string Name => "Creating comment";

        public void Execute(InsertCommentDto request)
        {
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
