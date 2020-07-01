using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class TypeUser : BaseEntity
    {
        public string Type { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
