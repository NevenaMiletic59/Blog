using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Application.Exeptions;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EFEditCommentCommand : IEditCommentCommand
    {
        private readonly BlogContext _context;
        public int Id => 15;

        public string Name => "Edit comment";

        public void Execute(CommentDto request)
        {
            var comment = _context.Comments.Find(request.Id);
            if (comment == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Comments));
            }

            if (comment.Comment != request.Comment)
            {

                comment.Comment = request.Comment;
            }

            _context.SaveChanges();
        }
    }
}
