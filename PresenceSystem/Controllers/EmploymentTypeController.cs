using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PresenceSystem.Models;
using PresenceSystem.Pageable.PresenceSystem.Pageable;
using PresentSystem.Models;
using PresentSystem.Services;

namespace PresentSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class EmploymentTypeController : Controller
    {
        private readonly IEmploymentTypeService _service;

        public EmploymentTypeController(IEmploymentTypeService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateEmploymentTypeModel model)
        {
            var result = await _service.Create(model);
            return Created($"api/EmploymentType/{result}",null);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _service.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] UpdateEmploymentTypeModel model,[FromRoute] int id)
        {
            await _service.Update(model,id);
            return Ok();
        }

        [HttpGet("pageable")]
        public async Task<ActionResult<IEnumerable<EmploymentTypeModel>>> GetAll([FromQuery]GetPageableQuery query)
        {
            var result = await _service.GetAll(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmploymentTypeModel>> GetById([FromRoute] int id)
        {
            var result = await _service.GetById(id);
            return Ok(result);

        }
    }
}
