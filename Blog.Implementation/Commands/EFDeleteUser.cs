using Blog.Application.Commands;
using Blog.Application.Exeptions;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EFDeleteUser : IDeleteUserCommand
    {
        private readonly BlogContext _context;

        public EFDeleteUser(BlogContext context)
        {
            _context = context;
        }

        public int Id => 2;

        public string Name =>"Deleting User";

        public void Execute(int request)
        {
           var user= _context.Users.Find(request);
            if (user == null)
            {
                throw new EntityNotFoundException(request,typeof(User));
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
