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
    public class MenuController : ControllerBase
    {
        private readonly UseCaseExecutor executor;
        private readonly IApplicationActor actor;

        public MenuController(UseCaseExecutor executor, IApplicationActor actor)
        {
            this.executor = executor;
            this.actor = actor;
        }
        // GET: api/Menu
        [HttpGet]
        public IActionResult GetMenues([FromQuery] MenuSearch search, [FromServices] IGetMenuQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/Menu/5
        [HttpGet("/menu/getOneMenu/{id}", Name = "GetMenu")]
        public IActionResult GetOneMenu(int id,[FromQuery] IGetOneMenuQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/Menu
        [HttpPost]
        public void Post([FromBody] MenuDto dto,[FromServices] ICreateMenuCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // PUT: api/Menu/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MenuDto dto,[FromServices] IEditMenuCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteMenuCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
