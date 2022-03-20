using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Domain.Interfaces;
using UserManagement.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserManagementController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserProcessor _userService;

        public UserManagementController(IMediator  mediator,IUserProcessor userService)
        {
            _mediator = mediator;
            _userService = userService;
        }
        // GET: api/<UserManagementController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserManagementController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var model = new GetUserWithIds() {
                UserIds = new List<long>() { id }
            };
            var results = await _mediator.Send(model);
            return Ok(results);
        }

        // POST api/<UserManagementController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserManagementController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserManagementController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost("ValidateUser")]
        [AllowAnonymous]
        public TokenResult ValidateUser(User user)
        {
            return _userService.ValidateUser();
        }
    }
}
