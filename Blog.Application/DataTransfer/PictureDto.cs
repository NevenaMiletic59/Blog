using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DataTransfer
{
    public class PictureDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PostId { get; set; }
    }
}
