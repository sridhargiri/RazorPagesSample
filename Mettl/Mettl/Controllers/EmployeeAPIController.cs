using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mettl.Models;
using Mettl.Services;

namespace Mettl
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeAPIController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeeAPIController(IEmployeeService service)
        {
            _service = service;
        }
        [HttpGet("GetById/{id}"), Produces("application/json")]
        public IActionResult GetById(int id)
        {
            var response = _service.GetById(id);
            return Ok(response);
        }
        /// <summary>
        /// Add employee
        /// </summary>
        /// <param name="model"></param>
        [HttpPost("Save")]
        public IActionResult SaveEmployee(EmployeeModel model)
        {
            return Ok(_service.Add(model));
        }
        /// <summary>
        /// get all
        /// </summary>
        /// <param name="model"></param>
        [HttpGet("Getall")]
        public IEnumerable<EmployeeModel> Getall()
        {
            return _service.GetAll();
        }
    }
}
