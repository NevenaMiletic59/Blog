using Blog.Application.DataTransfer;
using Blog.Application.Exeptions;
using Blog.Application.Queries;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Queries
{
    public class EFGetOneMenuQuery : IGetOneMenuQuery
    {
        private readonly BlogContext _context;

        public EFGetOneMenuQuery(BlogContext context)
        {
            _context = context;
        }

        public int Id => 12;

        public string Name => "Get one menu";

        public MenuDto Execute(int search)
        {
            var menu = _context.Manues.Find(search);
            if (menu == null)
            {
                throw new EntityNotFoundException(search, typeof(Menu));
            }

            return new MenuDto
            {
                 Id=menu.Id,
                  Link=menu.href,
                   MenuName=menu.Name


            };
        }
    }
}
