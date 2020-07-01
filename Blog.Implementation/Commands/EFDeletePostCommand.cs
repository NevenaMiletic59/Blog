using Blog.Application.Commands;
using Blog.Application.Exeptions;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EFDeletePostCommand : IDeletePostComman
    {
        private readonly BlogContext _context;

        public EFDeletePostCommand(BlogContext context)
        {
            _context = context;
        }

        public int Id => 6;

        public string Name => "Delete Post";

        public void Execute(int request)
        {
            var post = _context.Posts.Find(request);

            if (post == null)
            {
                throw new EntityNotFoundException(request, typeof(Post));
            }

            _context.Posts.Remove(post);

            _context.SaveChanges();
        }
    }
}
