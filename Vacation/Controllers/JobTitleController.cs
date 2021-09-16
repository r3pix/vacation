using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vacation.Models;
using Vacation.Services;

namespace Vacation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class JobTitleController : Controller
    {
        private readonly IJobTitleService _service;

        public JobTitleController(IJobTitleService service)
        {
            _service = service;
        }

            [HttpPost]
            public async Task<ActionResult> Create([FromBody] CreateJobTitleModel model)
            {
                var result = await _service.Create(model);
                return Created($"api/JobTitle/{result}", null);
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult> Delete([FromRoute] int id)
            {
                await _service.Delete(id);
                return Ok();
            }

            [HttpPut("{id}")]
            public async Task<ActionResult> Update([FromBody] UpdateJobTitleModel model, [FromRoute] int id)
            {
                await _service.Update(model, id);
                return Ok();
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<JobTitleModel>>> GetAll()
            {
                var departments = await _service.GetAll();
                return Ok(departments);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<IEnumerable<JobTitleModel>>> GetAll([FromRoute] int id)
            {
                var departments = await _service.GetById(id);
                return Ok(departments);
            }
        
    }
}
