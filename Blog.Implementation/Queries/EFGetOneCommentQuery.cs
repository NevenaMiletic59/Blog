using Blog.Application.DataTransfer;
using Blog.Application.Exeptions;
using Blog.Application.Queries;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Queries
{
    public class EFGetOneCommentQuery : IGetOneCommentQuery
    {
        private readonly BlogContext _context;

        public EFGetOneCommentQuery(BlogContext context)
        {
            _context = context;
        }

        public int Id => 14;

        public string Name => "Get one comment";

        public CommentDto Execute(int search)
        {
            var co = _context.Comments.Find(search);
            if (co == null)
            {
                throw new EntityNotFoundException(search, typeof(Comments));
            }

            return new CommentDto
            {
                Id = co.Id,
                Comment = co.Comment

            };
        }
    }
}
