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
    public class EFDeleteCommandCategory : IDeleteCategoryCommand
    {
        private readonly BlogContext _context;
        private readonly DeleteCategoryValidator _validator;

        public EFDeleteCommandCategory(BlogContext context, DeleteCategoryValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 8;

        public string Name => "DeleteCategory";

        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);
            var category = _context.Categories.Find(request);

            if (category == null)
            {
                throw new EntityNotFoundException(request, typeof(Category));
            }

            _context.Categories.Remove(category);

            _context.SaveChanges();
        }
    }
}
