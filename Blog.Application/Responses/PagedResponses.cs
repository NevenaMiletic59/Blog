using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Responses
{
   public class PagedResponses<T> where T : class
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }


        public IEnumerable<T> data { get; set; }
        public int PagesCount => (int)Math.Ceiling((float)TotalCount / ItemsPerPage);
    }
}
