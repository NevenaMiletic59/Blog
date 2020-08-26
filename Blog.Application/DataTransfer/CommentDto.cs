using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Application.DataTransfer
{
    public class CommentDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Comment { get; set; }
        
    }
}
