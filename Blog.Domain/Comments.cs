using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
   public  class Comments :BaseEntity
    {
        public string Comment { get; set;}
        public Post post { get; set; }
        public int IdPost { get; set; }
        public User user { get; set; }
        public int UserId { get; set; }
    }
}
