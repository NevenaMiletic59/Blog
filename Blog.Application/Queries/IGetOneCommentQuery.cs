using Blog.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Queries
{
    public interface IGetOneCommentQuery : IQuery<int, CommentDto>
    {
    }
}
