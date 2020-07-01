using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
   public class UserUseCase
    {
        public int Id { get; set; }
        public int UseCaseId { get; set; }
        public int UserId { get; set; }

        public virtual User user { get; set; }
    }
}
