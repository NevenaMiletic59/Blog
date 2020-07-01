using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool deleted { get; set; }

    }
}
