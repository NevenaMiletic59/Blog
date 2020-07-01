using Blog.Application.DataTransfer;
using Blog.Application.Queries;
using Blog.Application.Responses;
using Blog.Application.Search;
using Blog.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Queries
{
    public class EFGetCommentQuery : IGetCommentQuery
    {
        private readonly BlogContext _context;
        public int Id =>13;

        public string Name => "Get comments";

        public PagedResponses<CommentDto> Execute(CommentSearch search)
        {
            var query = _context.Comments.AsQueryable();
            var totalCount = query.Count();

            query = query.Skip((search.PageNumber - 1) * search.PerPage).Take(search.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / search.PerPage);

            var response = new PagedResponses<CommentDto>
            {
                CurrentPage = search.PageNumber,
                TotalCount = totalCount,
                 ItemsPerPage = pagesCount,
                 data = query.Select(p => new CommentDto
                {
                    Id = p.Id,
                    Comment = p.Comment


                })

            };
            return response;
        }
    }
}
