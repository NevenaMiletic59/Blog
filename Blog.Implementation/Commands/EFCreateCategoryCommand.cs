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
    public class EFCreateCategoryCommand : ICreateCategoryCommand
    {

        private readonly BlogContext _context;
        private readonly CategoryValidator _validator;

        public EFCreateCategoryCommand(BlogContext context, CategoryValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 7;

        public string Name => "Create new Category";

        public void Execute(CategoryDto request)
        {
            _validator.ValidateAndThrow(request);
            var category = new Category
            {
                 CategoryName=request.Name
            };
            _context.Categories.Add(category);

            _context.SaveChanges();


        }
    }
}
