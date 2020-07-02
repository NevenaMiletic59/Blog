using Blog.Application.DataTransfer;
using Blog.Application.Queries;
using Blog.Application.Search;
using Blog.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Queries
{
    public class EFGetMenuQuery : IGetMenuQuery
    {
        private readonly BlogContext _context;

        public EFGetMenuQuery(BlogContext context)
        {
            _context = context;
        }

        public int Id => 12;

        public string Name => "Get menus";

        public IEnumerable<MenuDto> Execute(MenuSearch search)
        {
            var query = _context.Manues.AsQueryable();

            if (search.MenuName != null)
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.MenuName.ToLower()));
            }
            return query.Select(m => new MenuDto
            {
                MenuName=m.Name,
                 Id=m.Id,
                  Link=m.href

            });
        }
    }
    }

