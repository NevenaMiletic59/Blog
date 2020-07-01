using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EFCreatePostCommand : ICreatePostCommand
    {


        private readonly BlogContext _context;

        public EFCreatePostCommand(BlogContext context)
        {
            _context = context;
        }

        public int Id => 5;

        public string Name => "Creating new post";

        public void Execute(InsertPostDto request)
        {
            var post = new Post
            {
                 Name=request.Name, 
                 UserId=request.UserId,
                  Description=request.Text,
                   CetegoryId=request.CategoryId


            };
            _context.Posts.Add(post);
            _context.SaveChanges();

            Picture pic = new Picture
            {
                Name = request.FileName,
                 IdPost = post.Id
            };
            _context.Add(pic);
            _context.SaveChanges();
        }
    }
}
