using Blog.Application.DataTransfer;
using Blog.Application.Queries;
using Blog.Application.Responses;
using Blog.Application.Search;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Queries
{
    public class EFGetCategoryQuery : IGetCategoriesQuery
    {
        private readonly BlogContext _context;

        public EFGetCategoryQuery(BlogContext context)
        {
            _context = context;
        }

        public int Id => 9;

        public string Name =>"Selecting all categories";

        public PagedResponses<CategoryDto> Execute(CategorySearch search)
        {
            var query = _context.Categories.AsQueryable();

            if (search.Keyword != null)
            {
                query = query.Where(c => c.CategoryName.ToLower().Contains(search.Keyword.ToLower()));

            }
            var skipCount = search.PerPage * (search.PageNumber - 1);
            var response = new PagedResponses<CategoryDto>
            {
                CurrentPage = search.PageNumber,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                data = query.Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name= c.CategoryName

              })
                    };
            return response;
           
        }
    }
}
