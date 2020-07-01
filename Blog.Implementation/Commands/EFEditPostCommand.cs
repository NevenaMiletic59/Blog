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
    public class EFEditPostCommand : IEditPostCommand
    {
        private readonly BlogContext _context;

        public EFEditPostCommand(BlogContext context)
        {
            _context = context;
        }

        public int Id => 21;

        public string Name => "Edit post";

        public void Execute(EditPostDto request)
        {

            var type = _context.Posts.Find(request.Id);
            if (type == null)
            {
                throw new EntityNotFoundException(request.Id,typeof(Post));
            }

            var id = type.Id;

            var slike = new Picture
            {
                Id = request.Id,
                Name = request.Pictures,
                 IdPost = id


            };


            type.pictures.Add(slike);

            type.Id = request.Id;
            type.Name = request.Name;
            type.Description = request.Text;

            _context.SaveChanges();
        }
    }
}
