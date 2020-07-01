using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class Post : BaseEntity
    {
        public string Description { get; set; }
         public string Name { get; set; }
        public User user{ get; set; }
        public int UserId { get; set; }

        public Category Category { get; set; }
        public int CetegoryId { get; set; }

        public ICollection<Picture> pictures { get; set; }
        public ICollection<Comments> comments { get; set; }



    }
}
