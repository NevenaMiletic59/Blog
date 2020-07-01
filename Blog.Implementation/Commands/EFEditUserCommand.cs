using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Application.Exeptions;
using Blog.DataAccess;
using Blog.Domain;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EFEditUserCommand : IEditUserCommand
    {
        private readonly BlogContext _context;

        public EFEditUserCommand(BlogContext context)
        {
            _context = context;
        }

        public int Id => 17;

        public string Name => "Edit user";

        public void Execute(UserDto request)
        {
            var user = _context.Users.Find(request.Id);
            if (user.Username != request.Username)
            {

                user.Username = request.Username;
            }
            if (user.Email != request.Email)
            {
                if (_context.Users.Any(c => c.Email == request.Email))
                {
                    throw new EntityAlredyExists();
                }
                user.Email = request.Email;

            }

            if (user.Password != request.Password)
            {
                if (_context.Users.Any(c => c.Password == request.Password))
                {
                    throw new EntityAlredyExists();
                }
                user.Password = request.Password;

            }

            _context.SaveChanges();
        }
    }
}
