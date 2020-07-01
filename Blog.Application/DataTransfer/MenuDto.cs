using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Application.DataTransfer
{
    public class MenuDto
    {
        public int Id { get; set; }
       [Required]
       [MinLength(3)]
        public string MenuName { get; set; }

        [Required]
        [MinLength(3)]
        public string Link { get; set; }
    }
}
