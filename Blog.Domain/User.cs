using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Domain
{
   public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public TypeUser userType { get; set; }
        public int IdType { get; set; }

        public ICollection<Post> posts { get; set; }
        public ICollection<Comments> comments { get; set; }

        public virtual ICollection<UserUseCase> UserUseCases { get; set; }
    }
}
