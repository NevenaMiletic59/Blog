using Blog.Application.Commands;
using Blog.Application.Exeptions;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EFDeleteCommandCategory : IDeleteCategoryCommand
    {
        private readonly BlogContext _context;

        public EFDeleteCommandCategory(BlogContext context)
        {
            _context = context;
        }

        public int Id => 8;

        public string Name => "DeleteCategory";

        public void Execute(int request)
        {
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
