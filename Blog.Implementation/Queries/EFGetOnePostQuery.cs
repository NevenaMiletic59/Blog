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
    public class EFGetOnePostQuery : IGetOnePostQuery
    {
        private readonly BlogContext _context;

        public EFGetOnePostQuery(BlogContext context)
        {
            _context = context;
        }

        public int Id => 22;

        public string Name => "Get one post";

        public PostDto Execute(int search)
        {
            var post = _context.Posts.Find(search);
            if (post == null)
            {
                throw new EntityNotFoundException(search, typeof(Post));
            }

            var onepost = new PostDto
            {
                 PostId = post.Id,
                 CategoryId=post.CetegoryId,
                  Description=post.Description, 
                   Name=post.Name,
                    UserId=post.UserId
                 


            };
            return onepost;
        }
    }
}
