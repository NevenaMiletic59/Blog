using Blog.Application.Commands;
using Blog.Application.Exeptions;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EFDeletePictureCommand : IDeletePictureCommand
    {
        private readonly BlogContext _context;

        public EFDeletePictureCommand(BlogContext context)
        {
            _context = context;
        }

        public int Id => 19;

        public string Name => "Delete picture";

        public void Execute(int request)
        {
            var picture = _context.Pictures.Find(request);

            if (picture == null)
            {
                throw new EntityNotFoundException(request, typeof(Picture));
            }

            _context.Pictures.Remove(picture);

            _context.SaveChanges();
        }
    }
}
