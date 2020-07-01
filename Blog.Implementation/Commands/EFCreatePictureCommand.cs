using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EFCreatePictureCommand : ICreatePictureCommand
    {
        private readonly BlogContext _context;
        public int Id => 18;

        public string Name =>"Add picture";

        public void Execute(PictureDto request)
        {
            var picture = new Picture
            {
                 Id=request.Id,
                  IdPost=request.PostId,
                   Name=request.Name
                   


            };
            _context.Pictures.Add(picture);
            _context.SaveChanges();
        }
    }
}
