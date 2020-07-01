using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EFCreateMenuCommand : ICreateMenuCommand
    {
        private readonly BlogContext _context;

        public EFCreateMenuCommand(BlogContext context)
        {
            _context = context;
        }

        public int Id => 10;

        public string Name => "Create menu";

        public void Execute(MenuDto request)
        {
            var menu = new Menu
            {
              Name=request.MenuName,
               href=request.Link
                


            };
            _context.Manues.Add(menu);
            _context.SaveChanges();
        }
    }
}
