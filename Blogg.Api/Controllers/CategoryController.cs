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
    public class CategoryController : ControllerBase
    {
        private readonly UseCaseExecutor executor;
        private readonly IApplicationActor actor;

        public CategoryController(UseCaseExecutor executor, IApplicationActor actor)
        {
            this.executor = executor;
            this.actor = actor;
        }
        // GET: api/Category
        [HttpGet]
        public IActionResult GetCategory([FromQuery] CategorySearch search, [FromServices] IGetCategoriesQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/Category/5
        [HttpGet("/category/get/{id}", Name = "GetCategory")]
        public IActionResult GetOneCategory(int id, [FromQuery] IGetOneCategoryQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/Category
        [HttpPost]
        public void Post([FromBody] CategoryDto dto,[FromServices]ICreateCategoryCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoryDto dto, [FromServices] IEditCategoryCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteCategoryCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
