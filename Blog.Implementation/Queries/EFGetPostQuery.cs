using Blog.Application;
using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Application.Queries;
using Blog.Application.Responses;
using Blog.Application.Search;
using Blog.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EFGetPostQuery : IGetPostQuery
    {
        private readonly BlogContext _context;
        public int Id => 4;

        public string Name => "Get  posts";

        public PagedResponses<PostDto> Execute(PostSearch search)
        {
            var query = _context.Posts.AsQueryable();

            if (search.Name != null)
            {
                var keyword = search.Name.ToLower();
                query = query.Where(x => x.Name.ToLower().Contains(keyword));
            }
            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponses<PostDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                data = query.Include(p => p.user).Include(p => p.pictures).Include(p => p.Category).Take(search.PerPage).Skip(skipCount).Select(p => new PostDto
                {
                    Name = p.Name,
                    Description = p.Description,
                    CategoryName = p.Category.CategoryName,
                    PostId = p.Id,
                    UserId = p.user.Id,
                    pictures = p.pictures.Select(x => new PictureDto
                    {
                        Name = x.Name,
                        Id = x.Id
                    }).ToList()

                }).ToList()


            };
            return response;
        }

    }
}
