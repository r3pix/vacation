using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PresenceSystem.Models;
using PresenceSystem.Pageable;
using PresenceSystem.Pageable.PresenceSystem.Pageable;
using PresenceSystem.Services;

namespace PresenceSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class PlaceController : Controller
    {
        private readonly IPlaceService _service;

        public PlaceController(IPlaceService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody]CreatePlaceModel model)
        {
            var result = await _service.Create(model);
            return Created($"api/Place/{result}",null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] UpdatePlaceModel model,[FromRoute] int id)
        {
            await _service.Update(model, id);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _service.Delete(id);
            return Ok();
        }

        [HttpGet("pageable")]
        public async Task<ActionResult<Pageable<PlaceModel>>> GetAll([FromQuery]GetPageableQuery query)
        {
            var results = await _service.GetAll(query);
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlaceModel>> GetById([FromRoute]int id)
        {
            var result = await _service.GetById(id);
            return Ok(result);
        }
    }
}
