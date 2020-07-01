using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Application.Queries;
using Blog.Application.Responses;
using Blog.Application.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EFGetUserCommand : IGetPostQuery
    {
        public int Id => 3;

        public string Name => throw new NotImplementedException();

        public PagedResponses<PostDto> Execute(PostSearch search)
        {
            throw new NotImplementedException();
        }
    }
}
