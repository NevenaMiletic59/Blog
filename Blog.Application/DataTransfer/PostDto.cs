using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DataTransfer
{
   public class PostDto
    {
        public int PostId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime date { get; set; }

        public string CategoryName{ get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public List<PictureDto> pictures { get; set; }

    }
}
