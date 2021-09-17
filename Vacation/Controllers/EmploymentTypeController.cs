using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    }
}
