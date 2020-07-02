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
    public class EFGetOneUser : IGetOneUserQuery
    {
        private readonly BlogContext _context;

        public EFGetOneUser(BlogContext context)
        {
            _context = context;
        }

        public int Id => 16;

        public string Name => "Get one user";

        public BlogContext Context => _context;

        public UserDto Execute(int search)
        {
            var user = Context.Users.Find(search);
            if (user == null)
            {
                throw new EntityNotFoundException(search, typeof(User));
            }

            return new UserDto
            {
                 Email=user.Email,
                  FirstName=user.FirstName, 
                   Id=user.Id,
                    LastName=user.LastName,
                     Password=user.Password,
                      Username=user.Username


            };
        }
    }
}
