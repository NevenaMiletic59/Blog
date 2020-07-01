using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class Picture  :BaseEntity
    {
        public string Name { get; set; }
        public Post post { get; set; }
        public int IdPost { get; set; }
    }
}
