using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application;
using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Application.Exeptions;
using Blog.Application.Helpers;
using Blog.Application.Queries;
using Blog.Application.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blogg.Api.Controllers
{

 
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly UseCaseExecutor executor;
        private readonly IApplicationActor actor;
        private readonly ICreatePostCommand _addPost;
        private readonly IEditPostCommand _editPost;

        public PostController(UseCaseExecutor executor, IApplicationActor actor, ICreatePostCommand addPost)
        {
            this.executor = executor;
            this.actor = actor;
            _addPost = addPost;
        }
        // GET: api/Post
        [HttpGet]
        public IActionResult GetPost(
            [FromQuery] PostSearch search,
            [FromServices] IGetPostQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/Post/5
        [HttpGet("/post/onee/{id}", Name = "GetPost")]
        public string GetOnePost(int id)
        {
            return "value";
        }
        public class AddPost
        {
            public int Id { get; set; }
            public IFormFile Image { get; set; }

            public string Name { get; set; }
            public string Text { get; set; }
            public int CategoryId { get; set; }
            public int UserId { get; set; }



        }

        // POST: api/Post
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromForm] AddPost p ) 
        {
            var ext = Path.GetExtension(p.Image.FileName);
            if (!FileUpload.AllowedExtensions.Contains(ext))
            {
                return UnprocessableEntity("Image extension is not allowed.");
            }
            try
            {
                var newFileName = Guid.NewGuid().ToString() + "_" + p.Image.FileName;

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", newFileName);
                p.Image.CopyTo(new FileStream(filePath, FileMode.Create));

                var post = new InsertPostDto
                {
                    Name = p.Name,
                    FileName = newFileName,
                    Text = p.Text,
                    CategoryId = p.CategoryId,
                    UserId = p.UserId,

                };
                _addPost.Execute(post);
                return StatusCode(201);

            }

            catch (EntityAlredyExists)
            {
                return NotFound();
            }

            catch (Exception e)
            {
                return StatusCode(500, "An error has occured.");
            }
        }

        // PUT: api/Post/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] AddPost p)
        {
            var ext = Path.GetExtension(p.Image.FileName);
            if (!FileUpload.AllowedExtensions.Contains(ext))
            {
                return UnprocessableEntity("Image extension is not allowed.");
            }
            try
            {
                var newFileName = Guid.NewGuid().ToString() + "_" + p.Image.FileName;

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", newFileName);
                p.Image.CopyTo(new FileStream(filePath, FileMode.Create));




                var post = new EditPostDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Text = p.Text,
                    Pictures = newFileName

                };
                _editPost.Execute(post);
                return StatusCode(201);

            }
            catch (EntityNotFoundException n)
            {
                return NotFound();
            }

            catch (Exception e)
            {
                return StatusCode(500, "An error has occured.");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeletePostComman command)
        {

            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
