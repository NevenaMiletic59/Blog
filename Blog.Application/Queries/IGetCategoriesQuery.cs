using Blog.Application.DataTransfer;
using Blog.Application.Responses;
using Blog.Application.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Queries
{
    public interface IGetCategoriesQuery : IQuery<CategorySearch, PagedResponses<CategoryDto>>
    {
    }
}
