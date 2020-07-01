using Blog.Application.Commands;
using Blog.Application.Exeptions;
using Blog.DataAccess;
using Blog.Domain;
using Blog.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EFDeletePictureCommand : IDeletePictureCommand
    {
        private readonly BlogContext _context;
        private readonly DeletePictureValidator _validator;

        public EFDeletePictureCommand(BlogContext context, DeletePictureValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 19;

        public string Name => "Delete picture";

        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);
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
