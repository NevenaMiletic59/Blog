using Blog.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Queries
{
   public  interface IGetOneMenuQuery : IQuery<int, MenuDto>
    {
    }
}
