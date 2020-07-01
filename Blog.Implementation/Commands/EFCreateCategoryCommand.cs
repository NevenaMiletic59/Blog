using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EFCreateCategoryCommand : ICreateCategoryCommand
    {

        private readonly BlogContext _context;

        public EFCreateCategoryCommand(BlogContext context)
        {
            _context = context;
        }

        public int Id => 7;

        public string Name => "Create new Category";

        public void Execute(CategoryDto request)
        {
            var category = new Category
            {
                 CategoryName=request.Name
            };
            _context.Categories.Add(category);

            _context.SaveChanges();


        }
    }
}
