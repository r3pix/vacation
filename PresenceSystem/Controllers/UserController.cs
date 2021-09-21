using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresenceSystem.Models;
using PresenceSystem.Pageable;
using PresenceSystem.Pageable.PresenceSystem.Pageable;
using Vacation.Models;
using Vacation.Models.Identity;
using Vacation.Services;

namespace Vacation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateUserModel model)
        {
            var result = await _service.Create(model);
            return Created($"api/User/{result}",null);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {

            await _service.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] UpdateUserModel model, [FromRoute] int id)
        {
             await _service.Update(model, id);
            return Ok();
        }

        [HttpGet("pageable")]
        public async Task<ActionResult<Pageable<UserTableModel>>> GetAll([FromQuery]GetPageableQuery query)
        {
            var results = await _service.GetAll(query);
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserTableModel>> GetById([FromRoute] int id)
        {
            var result = await _service.GetById(id);
            return Ok(result);
        }


    }
}
