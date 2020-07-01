using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.DataAccess;
using Blog.Domain;
using Blog.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EFCreatePictureCommand : ICreatePictureCommand
    {
        private readonly BlogContext _context;
        private readonly CreatePictureValidator _validator;

        public EFCreatePictureCommand(BlogContext context, CreatePictureValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 18;

        public string Name =>"Add picture";

        public void Execute(PictureDto request)
        {
            _validator.ValidateAndThrow(request);
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
