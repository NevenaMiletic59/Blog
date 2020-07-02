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
    public class EFEditMenuCommand : IEditMenuCommand
    {
        private readonly BlogContext _context;

        public EFEditMenuCommand(BlogContext context)
        {
            _context = context;
        }

        public int Id => 16;

        public string Name => "Edit menu";

        public void Execute(MenuDto request)
        {
            var menu = _context.Manues.Find(request.Id);
            if (menu == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Menu));
            }

            if (menu.Name != request.MenuName)
            {

                menu.Name = request.MenuName;
            }

            _context.SaveChanges();
        }
    }
}
