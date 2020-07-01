using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application;
using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blogg.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public RegisterController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }


        // POST: api/Register
        [HttpPost]
        public void Post([FromBody] RegisterUserDto dto,[FromServices] IRegisterUserCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

       
    }
}
