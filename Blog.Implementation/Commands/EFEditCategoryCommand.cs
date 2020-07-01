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
    public class EFEditCategoryCommand : IEditCategoryCommand
    {
        private readonly BlogContext _context;
        public int Id => 15;

        public string Name => "Edit Category";

        public void Execute(CategoryDto request)
        {
            var category = _context.Categories.Find(request.Id);
            if (category == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Category));
            }

            if (category.CategoryName != request.Name)
            {

                category.CategoryName = request.Name;
            }

            _context.SaveChanges();
        }
    }
}
