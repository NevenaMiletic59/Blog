using Blog.Application.DataTransfer;
using Blog.Application.Exeptions;
using Blog.Application.Queries;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using System.Text;

namespace Blog.Implementation.Queries
{
    public class EFGetOneCategoryQuery : IGetOneCategoryQuery
    {
        private readonly BlogContext _context;
        public int Id => 9;

        public string Name => "Get one category" ;

        public CategoryDto Execute(int search)
        {
            var category = _context.Categories.Find(search);
            if (category == null)
            {
                throw new EntityNotFoundException(search, typeof(Category));
            }

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.CategoryName


            };
        }
    }
}
