using Blog.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Search
{
    public class PostSearch : PagedSearch
    {
        public string Name { get; set; }
        public int? CategoryId { get; set; }
     
        public string searchString { get; set; }
    }
}
