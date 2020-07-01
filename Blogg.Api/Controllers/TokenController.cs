using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogg.Api.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blogg.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly JwtManager manager;

        public TokenController(JwtManager manager)
        {
            this.manager = manager;
        }

        // POST: api/Token
        [HttpPost]
        public IActionResult Post([FromBody] LoginRequets requets)
        {
            var token = manager.MakeToken(requets.Username, requets.Passwrod);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }
        public class LoginRequets
        {
            public string Username { get; set; }
            public string Passwrod { get; set; }
        }

      
    }
}
