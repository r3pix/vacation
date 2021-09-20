using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PresenceSystem.Models;
using PresenceSystem.Services;

namespace PresenceSystem.Properties
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class ListOfPresenceController : Controller
    {
        private readonly IListOfPresenceService _service;

        public ListOfPresenceController(IListOfPresenceService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody]CreateListOfPresenceModel model)
        {
            var result = await _service.Create(model);
            return Created($"api/ListOfPresence/{result}",null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] UpdateListOfPresenceModel model, [FromRoute] int id)
        {
            await _service.Update(model, id);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListOfPresenceTableModel>>> GetAll()
        {
            var result = await _service.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ListOfPresenceTableModel>> GetById([FromRoute]int id)
        {
            var result = await _service.GetById(id);
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }


    }
}
