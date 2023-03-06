using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace W1.Controllers
{
    [Route("api/[controller]")] //https://localhost:44377/api/employeev?api-version=3
    [ApiController]
    [ApiVersion("3.0")]
    public class EmployeeV2Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult("employees from v2 controller");
        }
    }
}
