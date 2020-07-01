using Blog.Application.Commands;
using Blog.Application.Exeptions;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EFDeleteCommentCommand : IDeleteCommnetCommand
    {
        private readonly BlogContext _context;
        public int Id => 13;

        public string Name => "Delete comment";

        public void Execute(int request)
        {
            var comment = _context.Comments.Find(request);

            if (comment == null)
            {
                throw new EntityNotFoundException(request, typeof(Comments));
            }

            _context.Comments.Remove(comment);

            _context.SaveChanges();
        }
    }
}
