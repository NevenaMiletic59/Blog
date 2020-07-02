using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application;
using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Application.Queries;
using Blog.Application.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blogg.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly UseCaseExecutor executor;
        private readonly IApplicationActor actor;

        public CommentController(UseCaseExecutor executor, IApplicationActor actor)
        {
            this.executor = executor;
            this.actor = actor;
        }
        // GET: api/Comment
        [HttpGet]
        public IActionResult GetComment([FromQuery] CommentSearch search,[FromServices] IGetCommentQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/Comment/5
        [HttpGet("{id}", Name = "GetComment")]
        public IActionResult GetOneComment(int id,[FromServices] IGetOneCommentQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/Comment
        [HttpPost]
        public void Post([FromBody] InsertCommentDto dto,[FromServices] ICreateCommentCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // PUT: api/Comment/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CommentDto dto,[FromServices] IEditCommentCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command,dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteCommnetCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
