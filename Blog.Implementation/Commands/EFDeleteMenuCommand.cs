using Blog.Application.Commands;
using Blog.Application.Exeptions;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EFDeleteMenuCommand : IDeleteMenuCommand
    {
        private readonly BlogContext _context;
        public int Id => 11;

        public string Name => "Delete menu";

        public void Execute(int request)
        {
            var menu = _context.Manues.Find(request);

            if (menu == null)
            {
                throw new EntityNotFoundException(request, typeof(Menu));
            }

            _context.Manues.Remove(menu);

            _context.SaveChanges();
        }
    }
}
