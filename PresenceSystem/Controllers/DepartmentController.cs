﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PresenceSystem.Pageable;
using PresenceSystem.Pageable.PresenceSystem.Pageable;
using PresenceSystem.Querries;
using Vacation.Models;
using Vacation.Services;

namespace Vacation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody]CreateDepartmentModel model)
        {
            var result = await _service.Create(model);
            return Created($"api/Department/{result}",null);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _service.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody]UpdateDepartmentModel model,[FromRoute] int id)
        {
            await _service.Update(model,id);
            return Ok();
        }

        [HttpGet("pageable")]
        public async Task<ActionResult<Pageable<DepartmentModel>>> GetAll([FromQuery]GetPageableQuery query)
        {
            var departments = await _service.GetAll(query);
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<DepartmentModel>>> GetAll([FromRoute]int id)
        {
            var departments = await _service.GetById(id);
            return Ok(departments);
        }
    }
}
